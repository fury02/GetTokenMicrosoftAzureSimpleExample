using System;

using ConsoleOneDriveNetFramework.IoC;
using ConsoleOneDriveNetFramework.AuthenticationHelpers;

namespace ConsoleOneDriveNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            ContainerSimpleInjector containerSimpleInjector = new ContainerSimpleInjector();

            //Аунтификация
            ISimpleAuthenticationAzure auth = containerSimpleInjector.container.GetInstance<ISimpleAuthenticationAzure>();
            string token = auth.GetAccsesTokenInteractive();

            Console.WriteLine(token);
            Console.ReadKey();
        }
    }
}
