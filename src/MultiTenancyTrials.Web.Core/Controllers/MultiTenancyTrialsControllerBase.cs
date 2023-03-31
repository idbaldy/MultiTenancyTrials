using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MultiTenancyTrials.Controllers
{
    public abstract class MultiTenancyTrialsControllerBase: AbpController
    {
        protected MultiTenancyTrialsControllerBase()
        {
            LocalizationSourceName = MultiTenancyTrialsConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
