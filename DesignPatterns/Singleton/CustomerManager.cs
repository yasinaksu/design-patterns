using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class CustomerManager
    {
        private static CustomerManager _customerManager;
        private string _uniqeKey;
        private CustomerManager()
        {
            _uniqeKey = Guid.NewGuid().ToString();
        }

        public static CustomerManager CreateAsSingleton()
        {
            return _customerManager ?? (_customerManager = new CustomerManager());
        }

        public void GenerateGuid()
        {
            Console.WriteLine(_uniqeKey);
        }
    }
}
