using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProxyStructure
{
    class ProxyStructure
    {
        static void Main(string[] args)
        {
            TuongLua tuongLua = new TuongLua();
            tuongLua.YeuCau();
            //Console.ReadKey();
        }
    }

    abstract class DoiTuong
    {
        public abstract void YeuCau();
    }

    class DoiTuongThuc : DoiTuong
    {
        public override void YeuCau()
        {
            Console.WriteLine("Da goi phuong thuoc DoiTuongThuc.YeuCau()");
        }
    }

    class TuongLua : DoiTuong
    {
        private DoiTuongThuc _doiTuongThuc;
        public override void YeuCau()
        {
            if (_doiTuongThuc == null)
            {
                _doiTuongThuc = new DoiTuongThuc();
            }

            _doiTuongThuc.YeuCau();
        }
    }
}
