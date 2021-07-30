using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsApp.Services
{
    public class Logger : ILogger
    {
        private readonly string _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
        public void Log(string message)
        {
            File.AppendAllText(_logFilePath, message);
        }

        public void LogException(Exception exception)
        {
            string message = $"Message:{exception.Message}\nStackTrace:\n{exception.StackTrace}\n";

            Log(message);
        }
    }
}
