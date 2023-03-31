using Abp.AspNetCore.Mvc.ViewComponents;

namespace MultiTenancyTrials.Web.Views
{
    public abstract class MultiTenancyTrialsViewComponent : AbpViewComponent
    {
        protected MultiTenancyTrialsViewComponent()
        {
            LocalizationSourceName = MultiTenancyTrialsConsts.LocalizationSourceName;
        }
    }
}
