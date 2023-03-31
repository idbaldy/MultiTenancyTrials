using Abp.AspNetCore.MultiTenancy;
using Abp.MultiTenancy;
using Abp.Web.Configuration;
using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using MultiTenancyTrials.Authorization.Roles;
using MultiTenancyTrials.Authorization.Users;
using MultiTenancyTrials.Configuration;
using MultiTenancyTrials.Localization;
using MultiTenancyTrials.MultiTenancy;
using MultiTenancyTrials.Timing;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Castle.MicroKernel.Registration;
using Abp.Web;
using Abp.AspNetCore.Configuration;

namespace MultiTenancyTrials
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    [DependsOn(typeof(AbpWebCommonModule))]
    public class MultiTenancyTrialsCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            MultiTenancyTrialsLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = MultiTenancyTrialsConsts.MultiTenancyEnabled;
            
            //Configuration.MultiTenancy.TenantIdResolveKey = "Abp-TenantId";
            Configuration.MultiTenancy.Resolvers.Add<DomainTenantResolveContributor>();
            Configuration.Modules.AbpWebCommon().MultiTenancy.DomainFormat = "{TENANCY_NAME}.localhost:44312";

            //IocManager.Register<IAbpWebCommonModuleConfiguration, AbpWebCommonModuleConfiguration>();
            //Configuration.MultiTenancy.Resolvers.Add<DomainTenantResolveContributor>();

            //var webCommonConfig = Configuration.Modules.AbpWebCommon();
            //webCommonConfig.MultiTenancy.DomainFormat = "{0}.localhost:44311";

            //IocManager.IocContainer.Register(Component.For<IAbpWebCommonModuleConfiguration>().UsingFactoryMethod(() => Configuration.Modules.AbpWebCommon()).LifestyleSingleton());
            //var webCommonConfig = Configuration.Get<IAbpWebCommonModuleConfiguration>();
            //webCommonConfig.MultiTenancy.DomainFormat = "{0}.localhost:44311";

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            
            Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = MultiTenancyTrialsConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = MultiTenancyTrialsConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MultiTenancyTrialsCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
