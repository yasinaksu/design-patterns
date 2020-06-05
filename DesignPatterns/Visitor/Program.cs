using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker emre = new Worker { Name = "Emre", Salary = 3500 };
            Worker emin = new Worker { Name = "Emin", Salary = 3200 };

            Manager yasin = new Manager() { Name = "Müdür Yasin", Salary = 8000 };
            Manager kerim = new Manager() { Name = "Müdür Kerim", Salary = 8100 };

            yasin.Subordinates.Add(kerim);
            kerim.Subordinates.Add(emre);
            kerim.Subordinates.Add(emin);

            OrganisationalStructure structure = new OrganisationalStructure(yasin);

            PayallVisitor payallVisitor = new PayallVisitor();
            PayriselVisitor payriselVisitor = new PayriselVisitor();

            structure.Accept(payallVisitor);
            structure.Accept(payriselVisitor);

            Console.ReadLine();
        }
    }
    class OrganisationalStructure
    {
        public readonly EmployeeBase Employee;

        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }
        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }
    abstract class EmployeeBase
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public abstract void Accept(VisitorBase visitor);
    }
    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }
    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }
    class PayallVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} was paid to {1}", worker.Salary, worker.Name);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} was paid to {1}", manager.Salary, manager.Name);
        }
    }
    class PayriselVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary was rised to {1}", worker.Name, worker.Salary*(decimal)1.25);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary was rised to {1}", manager.Name, manager.Salary*(decimal)1.10);
        }
    }
}
