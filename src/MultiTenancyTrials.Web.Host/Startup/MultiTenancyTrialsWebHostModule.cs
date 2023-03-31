using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MultiTenancyTrials.Configuration;

namespace MultiTenancyTrials.Web.Host.Startup
{
    [DependsOn(
       typeof(MultiTenancyTrialsWebCoreModule))]
    public class MultiTenancyTrialsWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MultiTenancyTrialsWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MultiTenancyTrialsWebHostModule).GetAssembly());
        }
    }
}
