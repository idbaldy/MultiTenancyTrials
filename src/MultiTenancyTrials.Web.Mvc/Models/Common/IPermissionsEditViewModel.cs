using System.Collections.Generic;
using MultiTenancyTrials.Roles.Dto;

namespace MultiTenancyTrials.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}