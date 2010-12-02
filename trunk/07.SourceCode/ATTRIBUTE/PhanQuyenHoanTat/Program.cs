using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanQuyenHoanTat
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class LopKiemTra
    {
        public static void ThucThi()
        { }
        public int GetInt()
        {
            return 10;
        }
        //public int 

    }


    class Quyen : Attribute
    {
        public string VaiTro { get; set; }
        public string[] GetArrayVaiTro()
        {
            string[] result;

            /// Lay tat ca thong tin vai tro duoc dinh nghia
            result = VaiTro.Split(',');

            /// Chinh sua, cat khoang trang
            for (int i = 0; i < result.Count(); i++)
            {
                result[i] = result[i].Trim();
            }
            
            return result;
        }
    }
    class _Quyen : Attribute
    {
        public string VaiTro { get; set; }
        public string[] GetArrayVaiTro()
        {
            string[] result = null;
            result = VaiTro.Split(',');
            for (int i = 0; i < result.Count(); i++)
            {
                result[i] = result[i].Trim();
            }
            return result;
        }
    }
}
