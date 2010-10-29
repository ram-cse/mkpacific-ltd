using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cách tự xác định 1 command ?
            Command[] cmd = { new BuyCommand(), new SellCommand() };
         
            foreach (Command c in cmd)
            {
                string s = c.GetName();
                Console.WriteLine(s);
                c.Execute();
            }

        }
    }

    public abstract class Command
    {
        protected string Name { get; set; }        
        //public abstract void GetName();
        public string GetName()
        {
            return this.Name;
        }
        public abstract void Execute();
        
    }

    public class BuyCommand : Command
    {
        // this.Name != base.Name
        string Name = "BUYYYYY";

        public BuyCommand()
        {
            this.Name = "BUY";
            //base.Name = "BASE-NAME";
        }
        public override void Execute()
        {
            Console.WriteLine("Buying...");
        }
    }

    public class SellCommand : Command
    {
        public SellCommand()
        {
            this.Name = "SEL";
        }
        public override void Execute()
        {
            Console.WriteLine("Selling...");
        }
    }    
}
