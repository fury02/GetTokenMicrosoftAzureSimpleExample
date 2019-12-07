using System;
using Microsoft.Identity.Client;

using ConsoleOneDriveNetFramework.AppConfigs;
using ConsoleOneDriveNetFramework.appHelpers;

namespace ConsoleOneDriveNetFramework.AuthenticationHelpers
{
    public class SimpleAuthenticationAzure : ISimpleAuthenticationAzure
    {
        private readonly IAuthenticationConfig authConfig;
        private readonly ILoggingConsole loggingConsole;
        private readonly ISettings settings;

        public SimpleAuthenticationAzure(ISettings appSettings, ILoggingConsole loggingConsole)
        {   
            this.loggingConsole = loggingConsole;
            this.settings = appSettings;

            this.authConfig = settings.GetAuthenticationConfig();
        }

        public string GetAccsesTokenInteractive()
        {
            try
            {
                IPublicClientApplication appPublicClient = PublicClientApplicationBuilder
                .Create(authConfig.ClientId)
                .WithAuthority(authConfig.Authority)
                .Build();

                AuthenticationResult appAuthResult = appPublicClient
                    .AcquireTokenInteractive(authConfig.Scopes)
                    .ExecuteAsync().Result;

                var token = appAuthResult.AccessToken;

                return token;
            }
            catch (Exception exception)
            {
                loggingConsole.ConsoleWrite(exception.StackTrace);
                return null;
            }
            
        }
    }
}