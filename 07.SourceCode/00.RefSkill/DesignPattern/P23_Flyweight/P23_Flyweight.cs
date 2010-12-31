using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace P23_Flyweight
{
    class P23_Flyweight
    {
        static void Main(string[] args)
        {
            int extrinsicstate = 22;
            FlyweithFactory factory = new FlyweithFactory();
            Flyweight fx = factory.GetFlyweight("X");
            fx.Operation(--extrinsicstate);
            Flyweight fy = factory.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);
            Flyweight fz = factory.GetFlyweight("Z");
            fz.Operation(--extrinsicstate);            
        }
    }

    class FlyweithFactory
    {
        private Hashtable flyweiths = new Hashtable();
        public FlyweithFactory()
        {
            flyweiths.Add("X", new ConcreteFlyweight());
            flyweiths.Add("Y", new ConcreteFlyweight());
            flyweiths.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return ((Flyweight)flyweiths[key]);
        }
    }

    abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }

    class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("Concrete Flyweight: " + extrinsicstate);
        }
    }

    class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("Unshared Concrete Flyweight: " + extrinsicstate);
        }
    }
}
