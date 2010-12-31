using System;

namespace MP
{
    class MoneyPacificProxy
    {
        public static void Main()
        {
            Proxy proxy = new Proxy();
            proxy.Request();
        }
    }

    abstract class Subject
    {
        public abstract void Request();
    }

    class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("RealSubject.Request()");
        }
    }

    class Proxy : Subject
    {
        private RealSubject _realSubject;

        public Proxy()
        {
            this._realSubject = new RealSubject();
        }
        public override void Request()
        {
            this._realSubject.Request();
        }
    }
}