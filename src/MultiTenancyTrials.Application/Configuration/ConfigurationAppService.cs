using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MultiTenancyTrials.Configuration.Dto;

namespace MultiTenancyTrials.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MultiTenancyTrialsAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
