using System;
using System.IO;

namespace PG332_SoftwareDesign_EksamenH21.util
{
    public sealed class Logger
    {
        private static readonly Lazy<Logger> Lazy =
            new(() => new Logger());

        public static Logger Instance => Lazy.Value;

        private Logger()
        {
        }

        public async void Write(string message)
        {
            String fileName = "log.txt";
            DateTime dateTime = DateTime.Now;
            using StreamWriter file = new(fileName, true);
            await file.WriteAsync($"{dateTime} : {message}{Environment.NewLine}");
        }
    }
}