using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("cached with memcache");
        }
    }
}
