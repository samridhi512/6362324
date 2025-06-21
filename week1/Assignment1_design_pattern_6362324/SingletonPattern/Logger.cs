using System;

namespace SingletonPatternExample
{
    public class Logger
    {
        
        private static Logger instance = null;

        private static readonly object lockObj = new object();

        
        private Logger()
        {
            Console.WriteLine("Logger initialized.");
        }

        
        public static Logger GetInstance()
        {
            // Double-check locking for thread safety
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new Logger();
                    }
                }
            }
            return instance;
        }

        
        public void Log(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }
    }
}

