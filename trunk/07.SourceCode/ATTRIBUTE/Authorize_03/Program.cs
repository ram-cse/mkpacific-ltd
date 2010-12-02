using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace Authorize_03
{
    #region MAIN
    class Program
    {
        static void Main(string[] args)
        {
            string userRoles = "Guest";
            userRoles = "Administrator";

            TestClass obj = new TestClass();

            if ((Abc.GetRoles(obj, "AutoExecuting")).Contains(userRoles))
            {
                obj.AutoExecuting();
            }
            else
            {
                Console.WriteLine("no permission");
            }

            if (Abc.GetRoles(typeof(TestClass), "Executing").Contains(userRoles))
            {
                TestClass.Executing();
            }
            else
            {
                Console.WriteLine("no permission");
            }
                        
        }
    }
    #endregion 

    #region CLASS
    public static class Abc
    {        
        public static void call()
        {
            Console.WriteLine("aaa");
        }

        public static string[] GetRoles(object obj, string methodName)
        {
            string[] result = null;
            Type t = obj.GetType();
            MethodInfo method = t.GetMethod(methodName);
            Authorize[] arrAttr = (Authorize[])method.GetCustomAttributes(typeof(Authorize), true);
            if(arrAttr.Count() == 0)
            {
                return null;
            }
            result = arrAttr[0].GetArrayRoles();
            return result;
        }

        public static string[] GetRoles(Type type, string methodName)
        {
            string[] result = null;
            //Type t = obj.GetType();
            MethodInfo method = type.GetMethod(methodName);
            Authorize[] arrAttr = (Authorize[])method.GetCustomAttributes(typeof(Authorize), true);
            if (arrAttr.Count() == 0)
            {
                return null;
            }
            result = arrAttr[0].GetArrayRoles();
            return result;
        }
    }

    class TestClass
    {        
        [Authorize(Roles="Administrator")]        
        public int GetInt()
        {
            return 10;
        }

        [Authorize(Roles = "Administrator")]
        public void AutoExecuting()
        {
            Console.WriteLine("[admin] auto executing...");
        }

        [Authorize(Roles = "Manager")]
        public static void Executing()
        {
            Console.WriteLine("[manager] This function is executing...");
        }
    }
    #endregion

    #region Attributes
    class Authorize : Attribute
    {
        public string Roles { get; set; }
        public string[] GetArrayRoles()
        {
            string[] result=this.Roles.Split(',');
            for (int i = 0; i < result.Count(); i++)
            {
                result[i] = result[i].Trim();
            }
            return result;
        }
    }
    #endregion
}
