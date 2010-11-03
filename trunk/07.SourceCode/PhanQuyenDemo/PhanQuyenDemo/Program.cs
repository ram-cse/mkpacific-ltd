using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace PhanQuyenDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IUser[] lstUser = new IUser[2];
            lstUser[0] = new Guest();
            lstUser[1] = new Administrator();

            ICommand curCmd = new LockedCommand();

            foreach (IUser u in lstUser)
            {
                Console.WriteLine(u.GetRoles());
                string uRole = u.GetRoles();

                MethodInfo curMethod = curCmd.GetType().GetMethod("Execute");
                
                //Type t = typeof(IUser);
                //MethodInfo curMethod = t.GetMethod("Execute");
                
                foreach(Attribute attr in curMethod.GetCustomAttributes(true))
                {
                    AuthorizeAttribute thuoctinh = (AuthorizeAttribute) attr;
                    
                    //if (thuoctinh.Roles == uRole)
                    if(thuoctinh.Roles.Contains(uRole))
                    {
                        curCmd.Execute();
                    }
                    else
                    {
                        Console.WriteLine("Ban khong co quyen thuc thi lenh nay!...");
                    }
                }
            }
            
        }
    }

    public interface IUser
    {        
        string GetRoles();
    }

    public class Guest : IUser
    {
        public string GetRoles()
        {            
            return this.GetType().Name;
        }
    }

    public class Administrator  : IUser
    {
        public string GetRoles()
        {
            return this.GetType().Name;
        }
    }
}
