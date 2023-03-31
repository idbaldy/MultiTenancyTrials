using System.Threading.Tasks;
using Abp.Application.Services;
using MultiTenancyTrials.Sessions.Dto;

namespace MultiTenancyTrials.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
