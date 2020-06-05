using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            
            Teacher ogretmen1 = new Teacher(mediator) { Name = "Öğretmen 1" };
            mediator.Teacher = ogretmen1;

            Student yasin = new Student(mediator) { Name = "Yasin" };
            Student emre = new Student(mediator) { Name = "Emre" };
            mediator.Students = new List<Student>();
            mediator.Students.Add(yasin);
            mediator.Students.Add(emre);

            ogretmen1.SendNewImageUrl("slide1.jpg");
            ogretmen1.RecieveQuestion("question 1", yasin);
            Console.ReadLine();
        }
    }
    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }
        public void SendQuestion(string question,Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }
        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }
    class Teacher : CourseMember
    {
        public string Name { get; set; }

        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("{2} teacher recieved {0} from {1}",question,student.Name,this.Name);
        }
        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("{1} Teacher changed slide : {0}",url,this.Name);
            Mediator.UpdateImage(url);
        }
        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("{2} Teacher answered the question {0} {1}",answer,student.Name,this.Name);
        }
    }
    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get;  set; }

        public void RecieveImage(string url)
        {
            Console.WriteLine("{1} student recieved image : {0}", url,this.Name);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("{1} student recieved answer : {0}",answer,this.Name);
        }
    }
}
