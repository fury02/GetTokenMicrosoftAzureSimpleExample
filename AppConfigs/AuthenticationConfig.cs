using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

using ConsoleOneDriveNetFramework.appHelpers;

namespace ConsoleOneDriveNetFramework.AppConfigs
{
    public class AuthenticationConfig : IAuthenticationConfig
    {
        public string Instance { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public IEnumerable<string> Scopes { get; set; }
        public string Authority
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, Instance, TenantId);
            }
        }
 
        public AuthenticationConfig ReadFromJsonFile(string appsettings, string instance, ILoggingConsole loggingConsole)
        {
            string directory = Directory.GetCurrentDirectory();
            this.Instance = instance;

            try
            {
                IConfigurationRoot configuration;

                var builder = new ConfigurationBuilder()
                    .SetBasePath(directory)
                    .AddJsonFile(appsettings); ;

                configuration = builder.Build();

                return configuration.Get<AuthenticationConfig>();
            }

            catch (FileNotFoundException exception)
            {
                loggingConsole.ConsoleWrite(exception);

                return null;
            }
        }
    }
}
