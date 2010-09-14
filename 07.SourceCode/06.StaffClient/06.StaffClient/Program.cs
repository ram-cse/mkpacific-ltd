using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using StaffClient;

namespace StaffClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            StaffClient client = new StaffClient();
            string s = client.DisplayStaff();
            Console.WriteLine(s);
            client.Close();

        }
    }
}
