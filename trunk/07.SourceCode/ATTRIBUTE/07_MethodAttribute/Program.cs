using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace _07_MethodAttribute
{
    class Transactionable : Attribute
    { }

    class TestClass
    {
        [Transactionable]
        public void Foo()
        { }

        public void Bar()
        { }

        [Transactionable]
        public void Baz()
        { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(TestClass);
            
            MethodInfo[] arrMethod = type.GetMethods();

            foreach (MethodInfo method in arrMethod)
            {
                foreach (Attribute attr in method.GetCustomAttributes(true))
                {
                    if (attr is Transactionable)
                    {
                        Console.WriteLine("{0} is transationable.", method.Name);
                    }
                }
            }
        }
    }

    
}
