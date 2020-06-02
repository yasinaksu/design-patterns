using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();

            Console.ReadLine();
        }
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }
    interface ILogging
    {
        void Log();
    }
    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }
    interface ICaching
    {
        void Cache();
    }
    class Authorizing : IAuthorizing
    {
        public void CheckUser()
        {
            Console.WriteLine("user checked");
        }
    }
    interface IAuthorizing
    {
        void CheckUser();
    }

    class CustomerManager
    {
        private CrossCuttingConcernsFacade _concerns;
        public CustomerManager()
        {
            _concerns = new CrossCuttingConcernsFacade();
        }

        public void Save()
        {
            _concerns.Authorizing.CheckUser();
            _concerns.Caching.Cache();
            _concerns.Logging.Log();
            Console.WriteLine("customer saved!");
        }
    }
    class CrossCuttingConcernsFacade
    {
        public ILogging Logging { get; set; }
        public ICaching Caching { get; set; }
        public IAuthorizing Authorizing { get; set; }
        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorizing = new Authorizing();
        }
    }
}
