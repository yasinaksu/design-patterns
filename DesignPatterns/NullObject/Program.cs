using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new NLogLogger());
            customerManager.Save();

            CustomerManagerTests test = new CustomerManagerTests();
            test.SaveTest();

            Console.ReadLine();
        }
    }
    class CustomerManager
    {
        private readonly ILogger _logger;

        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            Console.WriteLine("Saved");
            _logger.Log();
        }
    }
    interface ILogger
    {
        void Log();
    }
    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4Net");
        }
    }
    class NLogLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with NLog");
        }
    }
    class StubLogger : ILogger
    {
        private static StubLogger _stubLogger;
        private static object _lock = new object();
        private StubLogger()
        {

        }
        public static StubLogger GetStubLogger()
        {
            lock (_lock)
            {
                if (_stubLogger==null)
                {
                    _stubLogger = new StubLogger();
                }
            }
            return _stubLogger;
        }
        public void Log()
        {
            Console.WriteLine("Moc logger invoked.");
        }
    }
    class CustomerManagerTests
    {
        public void SaveTest()
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetStubLogger());
            customerManager.Save();
            Console.WriteLine("Test succed");
        }
    }
}
