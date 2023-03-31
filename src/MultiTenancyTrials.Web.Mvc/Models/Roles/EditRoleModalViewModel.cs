using Abp.AutoMapper;
using MultiTenancyTrials.Roles.Dto;
using MultiTenancyTrials.Web.Models.Common;

namespace MultiTenancyTrials.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
