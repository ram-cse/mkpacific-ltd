using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P4_CommandMP
{
    class P4_CommandMP
    {
        static void Main(string[] args)
        {
            BuyCommand buycmd = new BuyCommand();
            User store = new User();
            store.SetCommand(buycmd);
            store.ExecuteCommand();
        }
    }

    class WCFService
    {
        public void BuyAction()
        {
            Console.WriteLine("WCF Service Action...");
        }
    }

    interface IMPCommand
    {        
        void Execute();
    }

    class BuyCommand : IMPCommand
    {
        WCFService service;
        public BuyCommand()
        {
            service = new WCFService();
        }
        public void Execute()
        {
            service.BuyAction();
            //Console.WriteLine("Buying something");
        }
    }

    class User
    {
        private IMPCommand _command;
        public void SetCommand(IMPCommand command)
        {
            this._command = command;
        }
        public void ExecuteCommand()
        {
            this._command.Execute();
        }
    }
}
