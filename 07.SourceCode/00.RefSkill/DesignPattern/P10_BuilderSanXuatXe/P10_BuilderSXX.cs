using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P10_BuilderSanXuatXe
{
    class P10_BuilderSXX
    {
        static void Main(string[] args)
        {
        }
    }

    class NhaSanXuat
    {

    }

    public class CaiXe
    {
        public string KhungXe;
        public int BanhXe;
    }


    public abstract class XeCo
    {
        protected CaiXe caixe;
        public abstract void LamKhungXe();
        public abstract void LamBanhXe();

        public void GetResult()
        {
            this.LamKhungXe();
            this.LamBanhXe();
        }
    }

    public class XeMay : XeCo
    {
        public XeMay() : base() { }

        public override void LamKhungXe()
        {
            this.caixe.KhungXe = "khung nho, nhe";
        }
        public override void LamBanhXe()
        {
            this.caixe.BanhXe = 2;
        }
    }


}

