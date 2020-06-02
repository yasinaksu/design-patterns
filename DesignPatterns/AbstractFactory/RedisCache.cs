using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("cached with rediscache");
        }
    }
}
