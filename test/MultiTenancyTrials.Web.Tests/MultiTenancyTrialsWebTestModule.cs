using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MultiTenancyTrials.EntityFrameworkCore;
using MultiTenancyTrials.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MultiTenancyTrials.Web.Tests
{
    [DependsOn(
        typeof(MultiTenancyTrialsWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MultiTenancyTrialsWebTestModule : AbpModule
    {
        public MultiTenancyTrialsWebTestModule(MultiTenancyTrialsEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MultiTenancyTrialsWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MultiTenancyTrialsWebMvcModule).Assembly);
        }
    }
}