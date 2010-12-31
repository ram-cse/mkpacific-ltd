using System;

namespace P4_MoneyPacific
{
    class MainApp
    {
        public static void Main()
        {
            Receiver receiver = new Receiver();
            Command cmd = new ConcreteCommand(receiver);
            Invoker storeUser = new Invoker();
            storeUser.SetCommand(cmd);
            storeUser.ExecuteCommand();
        }
    }

    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Goi Money Pacific Concrete Command");
        }
    }

    abstract class Command
    {
        public Receiver receiver;
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }

    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver)
            : base(receiver)
        { }
        public override void Execute()
        {
            this.receiver.Action();
        }
    }

    class Invoker
    {
        Command _command;
        public void SetCommand(Command command)
        {
            this._command = command;
        }
        public void ExecuteCommand()
        {
            this._command.Execute();
        }
    }


}