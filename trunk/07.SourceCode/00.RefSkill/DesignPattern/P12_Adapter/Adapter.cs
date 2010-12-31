using System;
namespace GOF
{
    class MainApp
    {
        public static void Main()
        {
            Target target = new Adapter();
            target.Request();
        }
    }

    class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("Request...");
        }
    }

    class Adapter : Target
    {
        private Adaptee _adaptee = new Adaptee();
        public override void Request()
        {
            _adaptee.SpecifiRequest();
        }
    }


    class Adaptee
    {
        public void SpecifiRequest()
        {
            Console.WriteLine("Specific Request");
        }
    }
}