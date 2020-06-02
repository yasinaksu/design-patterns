using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("logged with nlogger");
        }
    }
}
