using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer { City = "Ankara", FirstName = "Yasin", LastName = "Anything", Id = 1 };
            Console.WriteLine("customer 1 firstname: "+customer1.FirstName);

            Customer customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Emre";
            Console.WriteLine("customer 1 firstname (after clone): " + customer1.FirstName);
            Console.WriteLine("customer 2 firstname: " + customer2.FirstName);
            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
