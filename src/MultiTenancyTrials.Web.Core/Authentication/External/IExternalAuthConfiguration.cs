using System.Collections.Generic;

namespace MultiTenancyTrials.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
