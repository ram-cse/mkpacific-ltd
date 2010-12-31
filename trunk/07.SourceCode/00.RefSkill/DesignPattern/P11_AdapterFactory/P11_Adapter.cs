using System;

namespace GOF
{
    class MainApp
    {
        static void Main()
        {
            Targer target = new Adapter();
            target.Request();

        }
    }

    class Targer
    {
        public virtual void Request()
        {
            Console.WriteLine("Call Targer Request");
        }
    }

    class Adapter : Targer
    {
        private Adaptee _adapte = new Adaptee();
        public override void Request()
        {
            base.Request();
            _adapte.SpecificRequest();
        }

    }

    class Adaptee 
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }
}