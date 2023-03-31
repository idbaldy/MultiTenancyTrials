using System.Collections.Generic;
using MultiTenancyTrials.Roles.Dto;

namespace MultiTenancyTrials.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
