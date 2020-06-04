using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //customerManager.MessageSenderBase = new EmailSender();
            customerManager.MessageSenderBase = new SmsSender();
            customerManager.Update();

            Console.ReadLine();
        }
    }
    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message saved");
        }

        public abstract void Send(Body body);
    }

    class EmailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} email sended",body.Title);
        }
    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} sms sended", body.Title);
        }
    }

    class CustomerManager
    {
        public MessageSenderBase MessageSenderBase { get; set; }       

        public void Update()
        {
            MessageSenderBase.Send(new Body { Title = "m title", Text = "m text" });
            Console.WriteLine("customer updated.");
        }
    }
}
