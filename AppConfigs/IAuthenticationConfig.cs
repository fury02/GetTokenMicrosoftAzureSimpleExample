using System.Collections.Generic;

using ConsoleOneDriveNetFramework.appHelpers;

namespace ConsoleOneDriveNetFramework.AppConfigs
{
    public interface IAuthenticationConfig 
    {
        string Instance { get; set; }
        string TenantId { get; set; }
        string ClientId { get; set; }
        IEnumerable<string> Scopes { get; set; }
        string Authority { get; }
        AuthenticationConfig ReadFromJsonFile(string appsettings, string instance, ILoggingConsole loggingConsole);
    }
}
