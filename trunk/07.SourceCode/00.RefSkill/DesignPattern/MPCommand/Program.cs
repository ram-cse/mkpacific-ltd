using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            Proxy proxy = new Proxy();
            proxy.Execute();
        }
    }

    abstract class ICommand
    {
        public string Name;
        public abstract void Execute();                
    }

    class BUYCommand : ICommand
    {
        public BUYCommand()
        {
            this.Name = "BUY";
        }

        public override void Execute()
        {
            Console.WriteLine("Executing BUY command...");
        }

        
    }

    class MPCOLCommand : ICommand
    {
        public MPCOLCommand()
        {
            this.Name = "MPCOL";
        }

        public override void Execute()
        {
            Console.WriteLine("Executing MPCOL command...");
        }

        
    }

    class Proxy : ICommand
    {
        private BUYCommand _buycommand;        

        public override void Execute()
        {
            if (_buycommand == null)
            {
                _buycommand = new BUYCommand();
            }
            _buycommand.Execute();
        }       
    }
}
