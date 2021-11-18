using System;
using System.IO;

namespace PG332_SoftwareDesign_EksamenH21.util
{
    public sealed class Logger
    {
        private static readonly Lazy<Logger> Lazy =
            new(() => new Logger());

        public static Logger Instance => Lazy.Value;

        private Logger() {}

        public static async void Write(string message)
        {
            var fileName = $"{ConfigFile.programFilesDir}progression-tracker-log.txt";
            var dateTime = DateTime.Now;
            await using StreamWriter file = new(fileName, true);
            await file.WriteAsync($"{dateTime} : {message}{Environment.NewLine}");
        }
    }
}