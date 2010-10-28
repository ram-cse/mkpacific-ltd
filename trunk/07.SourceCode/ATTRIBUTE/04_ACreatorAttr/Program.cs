using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_ACreatorAttr
{
    public class Creator : Attribute
    { 
        public string name;
        public string date;
        public string version;

        public Creator(string name, string date)
        {
            this.name = name;
            this.date = date;
            this.version = "0.1";
        }
    }

    [Creator("LE THANH DUNG", "10/28/2010")]
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(Program);
            object[] arrO = t.GetCustomAttributes(t,true);
            foreach (object o in arrO)
            {
                Console.WriteLine(o);
            }
        }
    }
}

/*
 * [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class Creator : System.Attribute {
    public Creator(string name, string date) {
        this.name = name;
        this.date = date;
        version = 0.1;
    }
    string date;
    string name;
    public double version;

}

[Creator("T", "05/01/2001", version = 1.1)]
class MainClass {
    static public void Main(String[] args) {
        for (int i = 0; i < args.Length; ++i)
            System.Console.WriteLine("Args[{0}] = {1}", i, args[i]);

    }
}
*/