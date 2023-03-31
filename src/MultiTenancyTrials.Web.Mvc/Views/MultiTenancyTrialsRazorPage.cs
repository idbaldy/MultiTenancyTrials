using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace MultiTenancyTrials.Web.Views
{
    public abstract class MultiTenancyTrialsRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MultiTenancyTrialsRazorPage()
        {
            LocalizationSourceName = MultiTenancyTrialsConsts.LocalizationSourceName;
        }
    }
}
