using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonalCar personalCar = new PersonalCar { Make = "BMW", Model = "3.20i", HirePrice = 2500 };
            SpecialOffer specialOffer = new SpecialOffer(personalCar, 10);
            Console.WriteLine("Normal Hire Price: {0}", personalCar.HirePrice);
            Console.WriteLine("Special Offer Hire Price: {0}", specialOffer.HirePrice);

            Console.ReadLine();
        }
    }

    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }
    class CommerciallCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        private readonly CarBase _carBase;
        private readonly int _discountPercentage;
        public SpecialOffer(CarBase carBase, int discountPercentage) : base(carBase)
        {
            _carBase = carBase;
            _discountPercentage = discountPercentage;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get { return _carBase.HirePrice * (1 - (decimal)_discountPercentage / 100); } set { } }
    }
}
