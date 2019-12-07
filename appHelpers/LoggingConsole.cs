using System;

namespace ConsoleOneDriveNetFramework.appHelpers
{
    public class LoggingConsole : ILoggingConsole
    {
        public void ConsoleWrite(object obj) => Console.WriteLine(obj);
    }
}
