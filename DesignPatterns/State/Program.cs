using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            ModifiedState modifiedState = new ModifiedState();
            modifiedState.DoAction(context);
            Console.WriteLine(context.GetState().ToString());

            Console.ReadLine();
        }
    }
    class Context
    {
        private IState _state;
        public void SetState(IState state)
        {
            _state = state;
        }
        public IState GetState()
        {
            return _state;
        }
    }
    interface IState
    {
        void DoAction(Context context);
    }

    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("state : modified");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Modified";
        }
    }
    class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("state : deleted");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Deleted";
        }
    }
    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("state : added");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Added";
        }
    }
}
