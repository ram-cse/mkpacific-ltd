using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotepadLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            CallToList();
        }

        static void CallToList()
        {
            string[] Employees = {"le thanh dung"
                                  , "truong thuong han"
                                  , "le hoang giang"
                                  , "tran tuan anh"
                                  , "nguyen manh quoc anh"};

            var emps = Employees.ToList();
            foreach (string e in emps)
            {
                Console.WriteLine(e);
            }
        }
    }


}
