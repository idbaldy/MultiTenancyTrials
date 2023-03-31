using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MultiTenancyTrials.Authorization;

namespace MultiTenancyTrials
{
    [DependsOn(
        typeof(MultiTenancyTrialsCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MultiTenancyTrialsApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MultiTenancyTrialsAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MultiTenancyTrialsApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
