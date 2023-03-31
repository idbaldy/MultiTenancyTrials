using Abp.Dependency;
using Abp.Extensions;
using Abp.MultiTenancy;
using Abp.Text;
using Abp.Web.MultiTenancy;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancyTrials
{
    public class CustomDomainTenantResolveContributor : ITenantResolveContributor, ITransientDependency
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebMultiTenancyConfiguration _multiTenancyConfiguration;
        private readonly ITenantStore _tenantStore;

        public CustomDomainTenantResolveContributor(
            IHttpContextAccessor httpContextAccessor,
            IWebMultiTenancyConfiguration multiTenancyConfiguration,
            ITenantStore tenantStore)
        {
            _httpContextAccessor = httpContextAccessor;
            _multiTenancyConfiguration = multiTenancyConfiguration;
            _tenantStore = tenantStore;
        }

        public int? ResolveTenantId()
        {
            if (_multiTenancyConfiguration.DomainFormat.IsNullOrEmpty())
            {
                return null;
            }

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                return null;
            }

            var hostName = httpContext.Request.Host.Host.RemovePreFix("http://", "https://").RemovePostFix("/");
            var domainFormat = _multiTenancyConfiguration.DomainFormat.RemovePreFix("http://", "https://").Split(':')[0].RemovePostFix("/");
            var result = new FormattedStringValueExtracter().Extract(hostName, domainFormat, true, '/');

            if (!result.IsMatch || !result.Matches.Any())
            {
                return null;
            }

            var tenancyName = result.Matches[0].Value;
            if (tenancyName.IsNullOrEmpty())
            {
                return null;
            }

            if (string.Equals(tenancyName, "www", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            // Allow the use of admin.domain.com as the host url.
            if (string.Equals(tenancyName, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            var tenantInfo = _tenantStore.Find(tenancyName);
            if (tenantInfo == null)
            {
                return null;
            }

            return tenantInfo.Id;
        }
    }
}
