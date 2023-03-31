using MultiTenancyTrials.Debugging;

namespace MultiTenancyTrials
{
    public class MultiTenancyTrialsConsts
    {
        public const string LocalizationSourceName = "MultiTenancyTrials";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "3fe9e268a6cd47f0864a92e87a0149fe";
    }
}
