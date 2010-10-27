using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_SubClass
{
    [AttributeUsage(
        AttributeTargets.Class | AttributeTargets.Assembly,
        AllowMultiple = true,
        Inherited = false)
    ]
    public class AuthorAttribute : Attribute
    {
        private string company;
        private string name;

        public AuthorAttribute(string name)
        {
            this.name = name;
            this.company = "";
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public string Name
        {
            get { return name; }
        }
    }

    [assembly: Author("Tom", Company = "MK Pacific.")]
    [Author("Tom", Company = "Abc Ltd.")]
    class SomeClass { }

    [Author("Lena")]
    public class SomeOtherClass
    { }

    [Author("FirstName")]
    [Author("Jack", Company = "Ltd.")]
    class MainClass
    {
        public static void Main()
        {
            
            Type type = typeof(SomeClass);

            object[] attrs = type.GetCustomAttributes(typeof(AuthorAttribute), true);

            foreach (AuthorAttribute a in attrs)
            {
                Console.WriteLine(a.Name + ", " + a.Company);
            }
        }
    }

}
/*

[Author("FirstName")]
[Author("Jack", Company = "Ltd.")]
class MainClass
{
    public static void Main()
    {
        Type type = typeof(MainClass);

        object[] attrs = type.GetCustomAttributes(typeof(AuthorAttribute), true);

        foreach (AuthorAttribute a in attrs)
        {
            Console.WriteLine(a.Name + ", " + a.Company);
        }
    }
}
 * 
// */