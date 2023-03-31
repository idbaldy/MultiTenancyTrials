using System.Collections.Generic;
using MultiTenancyTrials.Roles.Dto;

namespace MultiTenancyTrials.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
