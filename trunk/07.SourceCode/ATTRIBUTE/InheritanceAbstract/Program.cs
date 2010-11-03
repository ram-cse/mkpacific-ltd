using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAbstract
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] arrUser = new User[2];

            arrUser[0] = new Guest();
            arrUser[1] = new Admin();

            foreach (User u in arrUser)
            {
                Console.WriteLine(u.GetRoles());
            }
            
        }
    }

    abstract class User
    {
        public string GetRoles()
        {
            return this.GetType().Name;
        }
    }

    class Guest : User
    { }

    class Admin : User
    {     }

}

