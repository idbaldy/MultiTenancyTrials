using System.Threading.Tasks;
using Abp.Application.Services;
using MultiTenancyTrials.Authorization.Accounts.Dto;

namespace MultiTenancyTrials.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
