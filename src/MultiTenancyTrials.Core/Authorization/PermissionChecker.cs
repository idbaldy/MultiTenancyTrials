using Abp.Authorization;
using MultiTenancyTrials.Authorization.Roles;
using MultiTenancyTrials.Authorization.Users;

namespace MultiTenancyTrials.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
