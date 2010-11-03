using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
using System.Diagnostics;


namespace Authorize
{
    class Program
    {
        static void Main(string[] args)
        {
            string userRole_01 = "normal";
            string userRole_02 = "Administrator";

            // Muốn lấy thuộc tính của một phương thức
            // -> phải lấy được tên lớp của phương thức đó
            // -> & lấy đối tượng lớp cho vào Type
            //string attributeName = 
            //Type type = typeof(Command);

            Command cmd = new Command();
            Type type = cmd.GetType();
            MethodInfo currentMethod = cmd.GetType().GetMethod("PhuongThuc");

            foreach (Attribute attr in currentMethod.GetCustomAttributes(true))
            {
                Authorize thuoctinh = (Authorize)attr;
                
                //if (attr.ToString() == "Administrator")
                if(thuoctinh.Roles == "Administrator")
                {

                    Console.WriteLine("DUOC PHEP thuc thi 'PhuongThuc'");
                }
                else
                {
                    Console.WriteLine("KHONG DUOC PHEP thuc thi 'PhuongThuc'");
                }
            }


            foreach (MethodInfo method in type.GetMethods())
            {
                foreach (Attribute attr in method.GetCustomAttributes(true)) 
                {
                    Console.WriteLine("GET: " + method.Name + "->" + attr.ToString());
                }
            }

            //Command.ThucThi();
            //Command.AdminThucThi();
        }

        //static string GetRole(
    }

    class Command
    {
        [Authorize]
        public static void ThucThi()
        {
            Console.WriteLine("Command duoc thuc thi boi Normal User");
        }

        [Authorize(Roles = "Administrator")]
        public static void AdminThucThi()
        {
            Console.WriteLine("Command duoc thuc thi boi Administrator!..");
        }

        public Type GetMyType()
        {
            Type t = typeof(Command);
            return t;
        }
        //Adminstrator
        [Authorize(Roles = "Administrator")]
        public void PhuongThuc()
        { 

        }
    }

    class Authorize : Attribute
    {
        public string Roles { get; set; }
    }
}
