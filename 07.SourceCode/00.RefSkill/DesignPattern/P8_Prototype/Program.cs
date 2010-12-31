using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P8_Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            DoiTuongDonGian a = DoiTuongDonGian.ThucThe();
            a.Name = "LE THANH DUNG";
            DoiTuongDonGian b = DoiTuongDonGian.ThucThe();
            Console.WriteLine(b.Name);
                
        }
    }

    class DoiTuongDonGian
    {
        public string Name;
        private static DoiTuongDonGian _thucthe;
        public DoiTuongDonGian()
        {            
        }

        public static DoiTuongDonGian ThucThe()
        {
            if (_thucthe == null)
            {
                _thucthe = new DoiTuongDonGian();
            }

            return _thucthe;
        }
    }
}
