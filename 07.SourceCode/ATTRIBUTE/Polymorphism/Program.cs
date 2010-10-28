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
            Command[] cmd = { new BuyCommand(), new SellCommand() };
            foreach (Command c in cmd)
            {
                string s = c.GetName();
                Console.WriteLine(s);
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
    }

    public class BuyCommand : Command
    {
        string Name = "BUYYYYY";
        public BuyCommand()
        {
            this.Name = "BUY";
            base.Name = "BASE-NAME";
        }        
    }

    public class SellCommand : Command
    {
        public SellCommand()
        {
            this.Name = "SEL";
        }        
    }    
}
