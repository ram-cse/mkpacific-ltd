using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P9_Prototype
{
    class P9_Prototype
    {
        static void Main(string[] args)
        {
            VatThuc v1 = new VatThuc("I");
            VatThuc c1 = (VatThuc)v1.Clone();

            Console.WriteLine("Clone: {0}", c1.Id);

            VatThuc v2 = new VatThuc("II");
            VatThuc c2 = (VatThuc)v2.Clone();
            Console.WriteLine("Clone: {0}", c2.Id);

        }
    }

    abstract class VatMau
    {
        private string _id;
        public VatMau(string id)
        {
            this._id = id;
        }

        public string Id
        {
            get { return _id; }
        }
        public abstract VatMau Clone();
    }

    class VatThuc : VatMau
    {
        public VatThuc(string id)
            : base(id)
        { }

        public override VatMau Clone()
        {
            return (VatThuc)this.MemberwiseClone();
        }
    }

    
}
