using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MultiTenancyTrials.Configuration;
using MultiTenancyTrials.EntityFrameworkCore;
using MultiTenancyTrials.Migrator.DependencyInjection;

namespace MultiTenancyTrials.Migrator
{
    [DependsOn(typeof(MultiTenancyTrialsEntityFrameworkModule))]
    public class MultiTenancyTrialsMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MultiTenancyTrialsMigratorModule(MultiTenancyTrialsEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(MultiTenancyTrialsMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                MultiTenancyTrialsConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MultiTenancyTrialsMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
