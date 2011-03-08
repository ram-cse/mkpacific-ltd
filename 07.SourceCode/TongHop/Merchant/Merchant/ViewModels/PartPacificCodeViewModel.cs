using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSite.ViewModels
{
    public class PartPacificCodeViewModel
    {
        private string _partCodeNumber;

        public int Id;
        public int Stt;

        public string PartCodeNumber
        {
            get { return _partCodeNumber; }
            set { _partCodeNumber = value.Substring(0, 12); }
        }

        public string CustomerPhone;
        public string StorePhone;
        public int InitialAmount;
        public int ActualAmount;
        public DateTime CreateDate;
        //public DateTime LastDate;
        public DateTime ExpireDate;            
    }
}