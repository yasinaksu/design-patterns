using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductManager productManager = new ProductManager(new MyLogger());
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();

            Console.ReadLine();
        }
    }
    interface ILogger
    {
        void Log(string data);
    }

    class MyLogger : ILogger
    {
        public void Log(string data)
        {
            Console.WriteLine("{0} data was logged with mylogger",data);
        }
    }

    //imagine this class include project from another service so we cannot change anythings which in.
    class Log4Net
    {
        public void LogData(string data)
        {
            Console.WriteLine("logged with log4net {0}",data);
        }
    }

    class Log4NetAdapter : ILogger
    {
        public void Log(string data)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogData(data);
        }
    }
    class ProductManager
    {
        private ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("some log infos");
            Console.WriteLine("saved.");
        }
    }
}
