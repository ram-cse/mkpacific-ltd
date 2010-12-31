using System;
using System.Collections.Generic;

namespace ProxyStructure
{
    class MoneyPacific
    {
        public static void Main()
        {
            Proxy proxy = new Proxy();
            proxy.Reqest();
        }
    }

    abstract class Subject
    {
        public abstract void Reqest();
    }

    class RealSubject : Subject
    {
        public override void Reqest()
        {
            Console.WriteLine("REALSubject make reques... vn vd -> vd");
        }
    }

    class Proxy : Subject
    {
        private RealSubject _realObject;
        public override void Reqest()
        {
            if (_realObject == null)
            {
                _realObject = new RealSubject();
            }
            _realObject.Reqest();
        }      
        

    } 

}