using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace Authorize_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string curRole = "Administratort";
            
            // string[] arrS = { "abc", "def" };
            // bool b = arrS.Contains("abc");
            // Console.WriteLine(b);

            string[] arrRoles = SeparateArray(GetRoles("TestMethod"),',');
            if (arrRoles.Contains(curRole))
                Console.WriteLine("Executing...");
            else
                Console.WriteLine("No permissiong..");
        }

        static string[] SeparateArray(string orginalString, char c)
        {
            string[] result = orginalString.Split(c);
            
            for (int i = 0; i < result.Count(); i++)
            {
                result[i] = result[i].Trim();
            }

            return result;
        }
        static string GetRoles(string methodName, string className)
        {
            return "";
        }

        static string GetRoles(string methodName)
        {
            Program a = new Program();            
            //MethodInfo method = a.GetType().GetMethod(methodName);            
            MethodInfo me = a.GetType().GetMethod(methodName);

            MethodInfo[] arrMethod = typeof(Program).GetMethods();
            MethodInfo method = null;
            foreach (MethodInfo m in arrMethod)
            {
                if (m.Name == methodName) method = m;
            }

            method = me;
            AuthorizeAttribute[] arrAttr = (AuthorizeAttribute[])method
                .GetCustomAttributes(typeof(AuthorizeAttribute),true);

            if (arrAttr.Count() == 0)
                return "";
            else
                return arrAttr[0].Roles;            
        }

        [Authorize(Roles = "Administrator, Guest, Moderator")]
        public static void TestMethod()
        { }

        [Authorize(Roles = "Administrator, Guest")]
        static int GetMainId()
        {
            return 1;
        }
    }

    public class AuthorizeAttribute : Attribute
    {
        public string Roles { get; set; }
    }


}
