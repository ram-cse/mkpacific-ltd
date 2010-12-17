using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P3_FirstOrDefault
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 9, 20, 25, 71, 45, 26, 15 };
            var query = from n in numbers
                        where (n % 5) == 0
                        select n;
            foreach (int n in query)
            {
                Console.WriteLine(n);
            }
        }
    }
}
