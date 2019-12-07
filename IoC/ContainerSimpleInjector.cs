using SimpleInjector;
using ConsoleOneDriveNetFramework.AppConfigs;
using ConsoleOneDriveNetFramework.AuthenticationHelpers;
using ConsoleOneDriveNetFramework.appHelpers;

namespace ConsoleOneDriveNetFramework.IoC
{
    class ContainerSimpleInjector
    {
        public Container container;

        public ContainerSimpleInjector()
        {
            container = new Container();
            
            container.RegisterSingleton<IAuthenticationConfig, AuthenticationConfig>();
            container.RegisterSingleton<ISettings, Settings>();
            container.RegisterSingleton<ISimpleAuthenticationAzure, SimpleAuthenticationAzure>();
            container.RegisterSingleton<ILoggingConsole, LoggingConsole>();
        }

    }
}
