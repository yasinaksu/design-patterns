using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new Employee { Name = "Manager" };
            var chief1 = new Employee { Name = "Chief 1" };
            var chief2 = new Employee { Name = "Chief 2" };
            manager.AddSubordinate(chief1);
            manager.AddSubordinate(chief2);

            var employee1 = new Employee { Name = "Employee 1" };
            var employee2 = new Employee { Name = "Employee 2" };
            var employee3 = new Employee { Name = "Employee 3" };
            chief1.AddSubordinate(employee1);
            chief1.AddSubordinate(employee2);
            chief2.AddSubordinate(employee3);

            Console.WriteLine(manager.Name);

            foreach (Employee chiefInManager in manager)
            {
                Console.WriteLine(" "+ chiefInManager.Name);
                foreach (Employee employeeInChief in chiefInManager)
                {
                    Console.WriteLine("  "+ employeeInChief.Name);
                }
            }
            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();
        public string Name { get; set; }
        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }
        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
