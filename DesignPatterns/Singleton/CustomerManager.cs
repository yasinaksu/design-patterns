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
        private static object _lockObkect = new object();
        private CustomerManager()
        {
            _uniqeKey = Guid.NewGuid().ToString();
        }

        public static CustomerManager CreateAsSingleton()
        {        
            lock (_lockObkect)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }

            return _customerManager;
        }

        public void GenerateGuid()
        {
            Console.WriteLine(_uniqeKey);
        }
    }
}
