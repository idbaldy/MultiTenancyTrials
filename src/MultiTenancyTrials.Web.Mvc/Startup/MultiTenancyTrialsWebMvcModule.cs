using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MultiTenancyTrials.Configuration;

namespace MultiTenancyTrials.Web.Startup
{
    [DependsOn(typeof(MultiTenancyTrialsWebCoreModule))]
    public class MultiTenancyTrialsWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MultiTenancyTrialsWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<MultiTenancyTrialsNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MultiTenancyTrialsWebMvcModule).GetAssembly());
        }
    }
}
