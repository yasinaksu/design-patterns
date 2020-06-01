using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager1 = CustomerManager.CreateAsSingleton();
            var customerManager2 = CustomerManager.CreateAsSingleton();

            customerManager1.GenerateGuid();
            customerManager2.GenerateGuid();

            Console.ReadLine();
        }
    }
}
