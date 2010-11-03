using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanQuyenDemo
{
    public class BuyCommand : ICommand
    {
        [Authorize(Roles = "User")]
        public void Execute()
        {
            Console.WriteLine("Lenh BUY, moi user deu co the truy xuat");
        }
    }

    public class LockedCommand : ICommand
    {
        [Authorize(Roles="Administrator, Guest")]
        public void Execute()
        {
            Console.WriteLine("Lenh LOCKED, chi co admin moi co the truy xuat");
        }
    }

}
