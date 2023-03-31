using Abp.MultiTenancy;
using MultiTenancyTrials.Authorization.Users;

namespace MultiTenancyTrials.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
