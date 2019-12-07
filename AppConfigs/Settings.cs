using System;

using ConsoleOneDriveNetFramework.appHelpers;

namespace ConsoleOneDriveNetFramework.AppConfigs
{
    /// <summary>
    /// Настройки
    /// </summary>
    public class Settings : ISettings
    {
        public readonly string appSettings = String.Empty;
        public readonly string instance = String.Empty;

        private readonly IAuthenticationConfig authConfig;
        private readonly ILoggingConsole loggingConsole;

        public Settings(IAuthenticationConfig authConfig, ILoggingConsole loggingConsole)
        {
            this.authConfig = authConfig;
            this.loggingConsole = loggingConsole;
            this.appSettings = "appsettings.json";
        }

        /// <summary>
        /// Получение объекта AuthenticationConfig
        /// созданного на основе appsettings.json
        /// </summary>
        /// <returns></returns>
        public AuthenticationConfig GetAuthenticationConfig()
        {
            try
            {
                AuthenticationConfig authenticationConfig = authConfig.ReadFromJsonFile(appSettings, instance, loggingConsole);

                return authenticationConfig;
            }
            catch (Exception exception)
            {
                loggingConsole.ConsoleWrite(exception.StackTrace);

                return null;
            }

        }


    }
}
