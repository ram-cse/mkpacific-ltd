using System;
namespace DoFactory
{
    class MainApp
    {
        public static void Main()
        {
            AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);
            client1.Run();

            AbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new Client(factory2);
            client2.Run();
        }
    }

    #region FACTORY
    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }
    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
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
            Console.WriteLine(this.GetType().Name +
                " interact with " + a.GetType().Name);                 
        }
    }

    class ProductA2 : AbstractProductA { }
    class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name
                + " interact with " + a.GetType().Name);
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
            _abstractProductA = factory.CreateProductA();
        }

        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }
    #endregion CLIENT
}

#region A1
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Abstract_Factory
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            AbstractFactory factory1 = new ConcreteFactory1();
//            Client client1 = new Client(factory1);
//            client1.Run();
//            AbstractFactory factory2 = new ConcreteFactory2();
//            Client client2 = new Client(factory2);
//            client2.Run();
//        }
//    }

//    #region FACTORY
//    abstract class AbstractFactory
//    {
//        public abstract AbstractProductA CreateProductA();
//        public abstract AbstractProductB CreateProductB();
//    }
//    class ConcreteFactory1 : AbstractFactory
//    {
//        public override AbstractProductA CreateProductA()
//        {
//            return new ProductA1();
//        }
//        public override AbstractProductB CreateProductB()
//        {
//            return new ProductB1();
//        }
//    }

//    class ConcreteFactory2 : AbstractFactory
//    {
//        public override AbstractProductA CreateProductA()
//        {
//            return new ProductA2();
//        }
//        public override AbstractProductB CreateProductB()
//        {
//            return new ProductB2();
//        }
//    }

//    #endregion FACTORY

//    #region PRODUCT

//    abstract class AbstractProductA { }
//    abstract class AbstractProductB
//    {
//        public abstract void Interact(AbstractProductA a);
//    }

//    class ProductA1 : AbstractProductA { }
//    class ProductB1 : AbstractProductB
//    {
//        public override void Interact(AbstractProductA a)
//        {
//            Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
//        }
//    }
//    class ProductA2 : AbstractProductA { }
//    class ProductB2 : AbstractProductB
//    {
//        public override void Interact(AbstractProductA a)
//        {
//            Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
//        }
//    }
//    #endregion PRODUCT
    
//    #region CLIENT
//    class Client
//    {
//        private AbstractProductA _abstractProductA;
//        private AbstractProductB _abstractProductB;

//        public Client(AbstractFactory factory)
//        {
//            _abstractProductB = factory.CreateProductB();
//            _abstractProductA = factory.CreateProductA();
//        }

//        public void Run()
//        {
//            _abstractProductB.Interact(_abstractProductA);
//        }
//    }
//    #endregion CLIENT
//}
#endregion A1
