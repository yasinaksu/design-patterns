using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //customerManager.CreditCalculatorBase = new Before2010CustomerCreditCalculator();
            customerManager.CreditCalculatorBase = new After2010CustomerCreditCalculator();
            customerManager.GiveCredit();

            Console.ReadLine();
        }
    }
    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Before2010CustomerCreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated with before2010");
        }
    }
    class After2010CustomerCreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated with after2010");
        }
    }

    class CustomerManager
    {
        public CreditCalculatorBase CreditCalculatorBase { get; set; }
        public void GiveCredit()
        {
            Console.WriteLine("give credit process invoked");
            CreditCalculatorBase.Calculate();
        }
    }
}
