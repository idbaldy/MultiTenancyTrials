using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MultiTenancyTrials.Localization
{
    public static class MultiTenancyTrialsLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MultiTenancyTrialsConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MultiTenancyTrialsLocalizationConfigurer).GetAssembly(),
                        "MultiTenancyTrials.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
