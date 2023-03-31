using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MultiTenancyTrials.Controllers;

namespace MultiTenancyTrials.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : MultiTenancyTrialsControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
