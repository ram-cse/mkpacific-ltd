using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificBlackBox.DAO;
using MoneyPacificBlackBox.BUS;
using System.Xml.Serialization;

namespace MoneyPacificBlackBox.DTO
{
    //[Serializable]
    //[XmlRoot("PacificCodeViewModel")] 
    public class PacificCodeViewModel
    {
        private PacificCode _pacificCode;

        internal PacificCodeViewModel()
        {}

        //[XmlElement("PartCodeNumber")] 
        public string PartCodeNumber;

        //[XmlElement("CodeNumber")] 
        public string CodeNumber;

        //[XmlElement("ActualAmount")] 
        public int ActualAmount;

        //[XmlElement("InitialAmount")] 
        public int InitialAmount;

        //[XmlElement("CreateDate")] 
        public DateTime CreateDate;

        //[XmlElement("ExpireDate")] 
        public DateTime ExpireDate;


        internal void SetAttritebuteValue(PacificCode pacificCode)
        {
            this._pacificCode = pacificCode;

            this.CodeNumber = pacificCode.CodeNumber;
            this.PartCodeNumber = pacificCode.CodeNumber.Substring(0, 12);
            this.ActualAmount = (int)pacificCode.ActualAmount;
            this.InitialAmount = (int)pacificCode.InitialAmount;
            this.ExpireDate = (DateTime)pacificCode.ExpireDate;
            this.CreateDate= (DateTime)pacificCode.CreateDate;
        }
    }
}