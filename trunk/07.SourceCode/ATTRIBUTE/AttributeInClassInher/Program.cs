using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;

namespace AttributeInClassInher
{
    public class Started
    {
        public static void Main()
        {
            GenericIdentity g = new GenericIdentity("Person1");
            GenericPrincipal p = new GenericPrincipal(g, new string[] { "Manager" });
            //GenericPrincipal p = new GenericPrincipal(g, new string[] { "Manager" ,"Accountant" });
            Thread.CurrentPrincipal = p;
            MyClass.MethodA();
            YClass.MethodA();
        }
    }

    [PrincipalPermission(SecurityAction.Demand, Role = "Manager")]
    public class MyClass
    {
        static public void MethodA()
        {
            Console.WriteLine("MyClass.MethodA");
        }
    }

    [PrincipalPermission(SecurityAction.Demand, Role = "Accountant")]
    public class YClass : MyClass
    {
        static public void MethodB()
        {
            Console.WriteLine("MyClass.MethodB");
        }
    }
}
