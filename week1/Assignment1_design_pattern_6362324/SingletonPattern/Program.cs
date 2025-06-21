using System;

namespace SingletonPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Singleton Logger...\n");

            Logger logger1 = Logger.GetInstance();
            logger1.Log("This is the first log message.");

            Logger logger2 = Logger.GetInstance();
            logger2.Log("This is the second log message.");

            
            if (object.ReferenceEquals(logger1, logger2))
            {
                Console.WriteLine("\nBoth logger1 and logger2 reference the SAME instance. Singleton works!");
            }
            else
            {
                Console.WriteLine("\nDifferent instances were created. Singleton FAILED.");
            }
        }
    }
}
