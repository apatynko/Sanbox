using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsApp.Services
{
    public interface ILogger
    {
        void Log(string message);
        void LogException(Exception exception);
    }
}
