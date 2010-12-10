using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abstract_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    #region FACTORY
    abstract class AbstractFactory
    {
        internal AbstractProductB CreateProductB()
        {
            throw new NotImplementedException();
        }

        internal AbstractProductB CreateProductA()
        {
            throw new NotImplementedException();
        }
    }
    #endregion FACTORY

    #region PRODUCT

    abstract class AbstractProductA { }
    abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }

    class ProductA1 : AbstractProductA { }
    class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interacts + with " + a.GetType().Name);
        }
    }
    class ProductA2 : AbstractProductA { }
    class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
        }
    }
    #endregion PRODUCT
    
    #region CLIENT
    class Client
    {
        private AbstractProductA _abstractProductA;
        private AbstractProductB _abstractProductB;

        public Client(AbstractFactory factory)
        {
            _abstractProductB = factory.CreateProductB();
            _abstractProductB = factory.CreateProductA();
        }

        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }
    #endregion CLIENT
}

