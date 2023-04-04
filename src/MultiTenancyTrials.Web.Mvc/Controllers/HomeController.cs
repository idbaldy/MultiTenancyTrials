using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MultiTenancyTrials.Controllers;
using MultiTenancyTrials.Authorization.Users;
using Abp.Web.Sessions;
using MultiTenancyTrials.MultiTenancy;
using System.Threading.Tasks;

namespace MultiTenancyTrials.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MultiTenancyTrialsControllerBase
    {
        private readonly UserManager _userManager;
        private readonly SessionScriptManager _sessionScriptManager;
        private readonly TenantManager _tenantManager;

        public HomeController(UserManager userManager, SessionScriptManager sessionScriptManager, TenantManager tenantManager)
        {
            _userManager = userManager;
            _sessionScriptManager = sessionScriptManager;
            _tenantManager = tenantManager;
        }

        public async Task<ActionResult> Index()
        {
            var user = await _userManager.FindByEmailAsync("companyb@gmail.com");
            string userTenancy = await GetTenancyFromUserId(user.Id);

            var targetId = AbpSession.UserId;
            var target = _userManager.GetUserById((long)targetId);
            string targetTenancy = await GetTenancyFromUserId(target.Id);

            return View();
        }

        private async Task<string> GetTenancyFromUserId(long id)
        {
            var user = await _userManager.GetUserByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            var tenantId = user.TenantId;
            if (tenantId == null)
            {
                return null;
            }

            var tenant = await _tenantManager.GetByIdAsync((int)tenantId);
            if (tenant == null)
            {
                return null;
            }

            return tenant.TenancyName;
        }
    }
}
