using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MultiTenancyTrials.Authorization.Roles;
using MultiTenancyTrials.Authorization.Users;
using MultiTenancyTrials.MultiTenancy;

namespace MultiTenancyTrials.EntityFrameworkCore
{
    public class MultiTenancyTrialsDbContext : AbpZeroDbContext<Tenant, Role, User, MultiTenancyTrialsDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MultiTenancyTrialsDbContext(DbContextOptions<MultiTenancyTrialsDbContext> options)
            : base(options)
        {
        }
    }
}
