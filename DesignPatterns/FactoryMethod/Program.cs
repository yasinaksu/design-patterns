using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            CustomerManager customerManager = new CustomerManager(new AnotherLoggerFactory());
            customerManager.Save();

            Console.ReadLine();
        }
    }
}
