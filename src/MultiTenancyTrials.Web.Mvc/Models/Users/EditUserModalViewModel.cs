using System.Collections.Generic;
using System.Linq;
using MultiTenancyTrials.Roles.Dto;
using MultiTenancyTrials.Users.Dto;

namespace MultiTenancyTrials.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
