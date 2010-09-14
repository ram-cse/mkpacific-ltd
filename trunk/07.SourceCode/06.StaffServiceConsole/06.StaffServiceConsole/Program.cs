using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;


namespace _06.StaffServiceConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(Staff));
            try
            {
                sh.Open();
                Console.WriteLine("Staff service opened successfully");
                Console.WriteLine("Press Enter to terminate Staff Service");
                Console.ReadLine();
            }
            finally
            {
                sh.Close();
            }
        }
    }
}
