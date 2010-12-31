using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace P22_Flyweight
{
    class P22_Flyweight
    {
        static void Main(string[] args)
        {
            int extrinsicstate = 2;

            FlyweightFactory factory = new FlyweightFactory();
            Flyweight fx = factory.GetFlyweight("X");

            fx.Operation(--extrinsicstate);
            Flyweight fy = factory.GetFlyweight("Y");

            fy.Operation(--extrinsicstate);
            Flyweight fz = factory.GetFlyweight("Z");

            fz.Operation(--extrinsicstate);

            UnsharedConcreteFlyweight fu = new
                UnsharedConcreteFlyweight();
            fu.Operation(--extrinsicstate);

            Console.ReadKey();
        }
    }

    class FlyweightFactory
    {
        private Hashtable flyweights = new Hashtable();
        public FlyweightFactory()
        {
            flyweights.Add("X", new ConcreteFlyweight());
            flyweights.Add("Y", new ConcreteFlyweight());
            flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return ((Flyweight)flyweights[key]);
        }
    }

    abstract class Flyweight
    {
        public abstract void Operation(int extrisicstate);
    }

    class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrisicstate)
        {
            Console.WriteLine("ConcreteFlyweight: " + extrisicstate);
        }
    }

    class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrisicstate)
        {
            Console.WriteLine("UnsharedConcreteFlyweight: " + extrisicstate);
        }
    }
}
