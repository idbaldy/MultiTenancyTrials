using Abp.AutoMapper;
using MultiTenancyTrials.Sessions.Dto;

namespace MultiTenancyTrials.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
