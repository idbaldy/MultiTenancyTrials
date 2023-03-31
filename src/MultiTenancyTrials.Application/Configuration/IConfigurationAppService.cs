using System.Threading.Tasks;
using MultiTenancyTrials.Configuration.Dto;

namespace MultiTenancyTrials.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
