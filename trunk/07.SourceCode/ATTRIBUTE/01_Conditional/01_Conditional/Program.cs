#define TRIAL
// #define RELEASE // change to RELEASE when you want to release 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;


namespace _01_Conditional
{
    class Program
    {
        [Conditional("TRIAL")]
        void trial()
        {
            Console.WriteLine("Trial version, not for distribution");
        }

        [Conditional("RELEASE")]
        void release()
        {
            Console.WriteLine("Final release version");
        }

        static void Main(string[] args)
        {
            Program a = new Program();
            a.trial();
            a.release();
        }
    }
}
