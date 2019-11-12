using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsAB
{
    class LoggerSingleton
    {
        private LoggerSingleton()
        {
        }

        private int _logCount = 0;
        private static LoggerSingleton _loggerSingletonInstance = null;

        public static LoggerSingleton GetInstance()
        {
            if (_loggerSingletonInstance == null)
            {
                _loggerSingletonInstance = new LoggerSingleton();
            }

            return _loggerSingletonInstance;
        }

        public void Log(String message)
        {
            Console.WriteLine(_logCount + ": " + message);
            _logCount++;
        }

    }

    public static class HardWorkHelper
    {
        public static void DoHardWork()
        {
            LoggerSingleton logger = LoggerSingleton.GetInstance();
            HardProcessor processor = new HardProcessor(1);
            logger.Log("Hard work started...");
            processor.ProcessTo(5);
            logger.Log("Hard work finished...");
        }

        public static void DoHardWorkThreadSafety()
        {
            ThreadSafeLoggerSingleton logger = ThreadSafeLoggerSingleton.GetInstance();
            HardProcessor processor = new HardProcessor(1);
            logger.Log("Thread safe hard work started...");
            processor.ProcessTo(5);
            logger.Log("Thread safe hard work finished...");
        }
    }

    class HardProcessor
    {
        private int _start;
        public HardProcessor(int start)
        {
            _start = start;
            LoggerSingleton.GetInstance().Log("Processor just created.");
        }
        public int ProcessTo(int end)
        {
            int sum = 0;
            for (int i = _start; i <= end; ++i)
            {
                sum += i;
            }
            LoggerSingleton.GetInstance().Log(
                "Processor just calculated some value: " + sum);
            return sum;
        }
    }

    public class ThreadSafeLoggerSingleton
    {
        private ThreadSafeLoggerSingleton()
        {
            // Read data from some file and get the number of last entry
            // _logCount = the value that was read
        }
        private int _logCount = 0;
        private static ThreadSafeLoggerSingleton _loggerInstance;
        private static readonly object locker = new object();
        public static ThreadSafeLoggerSingleton GetInstance()
        {
            lock (locker)
            {
                if (_loggerInstance == null)
                {
                    _loggerInstance = new ThreadSafeLoggerSingleton();
                }
            }
            return _loggerInstance;
        }
        public void Log(String message)
        {
            Console.WriteLine(_logCount + ": " + message);
            _logCount++;
        }
    }
}
