using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P14_MPComposite
{
    class P14_MoneyPacificCom
    {
        static void Main(string[] args)
        {
            HopTu root = new HopTu("root");
            NutLa laDauTien = new NutLa("La A");
            root.Add(laDauTien);
            root.Add(new NutLa("La B"));

            HopTu ht = new HopTu("Nhanh X");
            ht.Add(new NutLa("La XA"));
            ht.Add(new NutLa("La XB"));

            root.Add(ht);

            NutLa lC = new NutLa("La C");
            NutLa lD = new NutLa("La D");

            root.Add(lC);
            root.Add(lD);

            root.Remove(lC);

            laDauTien.DatTen("Ten Rieng");

            root.Display(2);
        }
    }

    abstract class PhanTu
    {
        protected string ten;
        public PhanTu(string ten)
        {
            this.ten = ten;
        }

        internal void DatTen(string ten)
        {
            this.ten = ten;
        }

        public abstract void Add(PhanTu ptu);
        public abstract void Remove(PhanTu ptu);
        public abstract void Display(int depth);        
    }

    class HopTu : PhanTu
    {
        private List<PhanTu> _phanTuCon = new List<PhanTu>();

        public HopTu(string ten)
            : base(ten)
        { }

        public override void Add(PhanTu ptu)
        {
            this._phanTuCon.Add(ptu);
        }

        public override void Remove(PhanTu ptu)
        {
            this._phanTuCon.Remove(ptu);
        }

        public override void Display(int depth)
        {
            Console.WriteLine( new String('-',depth) + this.ten);
            foreach (PhanTu ht in this._phanTuCon)
            {
                ht.Display(depth + 2);
            }
        }
    }

    class NutLa : PhanTu
    {
        public NutLa(string ten)
            : base(ten)
        { }

        public override void Add(PhanTu ptu)
        {
            throw new Exception();
        }

        public override void Remove(PhanTu ptu)
        {
            throw new Exception();
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + this.ten);
        }
    }

}
