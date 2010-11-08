using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using P4_MoneyPacificSite.Models;

namespace P4_MoneyPacificSite.ViewModels
{
    #region MODELS

    public class StoreMangerViewModel
    {
    }

    public class StoreManagerInterfaceViewModel
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public int TotalTransaction { get; set; }
        public int TotalLastMonthAmount { get; set; }
        public DateTime LastCollectDate { get; set; }
        public bool IsLocked { get; set; }

        public int Id { get; set; }
    }

    public class CollectNumberModel
    {
        public List<StoreManagerAmountModel> lstManagerAmount;
        public List<Agent> lstAgent;
    }


    public class StoreManagerAmountModel
    {
        public int Id;
        public string Area;
        public int IdShop;
        public string Address;
        public int Balance;
        public string CodeNumber;
        public int AgentId;
        public bool Checked;
    }    

    #endregion

    #region SERVICES
    
   
    #endregion

    #region VERIDATIONS
    #endregion

}