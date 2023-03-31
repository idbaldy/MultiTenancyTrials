using Abp.Application.Services;
using MultiTenancyTrials.MultiTenancy.Dto;

namespace MultiTenancyTrials.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

