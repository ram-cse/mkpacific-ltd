using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using F5_MoneyPacificSite.Models;
using System.ComponentModel;

namespace F5_MoneyPacificSite.ViewModels
{
    #region MODELS
    public class AdminListAmountViewModel
    {
        public List<StoreManagerBalanceSelect> StoreManagers { get; set; }        
        public List<Agent> Agents { get; set; }
        public int AgentIdSelected { get; set; }
    }

    //public class AdminCollectProcessingListViewModel
    //{
    //    public List<CollectMoneyView> collectMoneyViews { get; set; }
    //}

    public class CollectMoneyView
    {

        public int Id { get; set; }

        [DisplayName("Store Manager Phone")]
        public string ManagerPhone { get; set; }

        [DisplayName("Store Manager Name")]
        public string ManagerName { get; set; }
        
        [DisplayName("Collect Number")]
        public string CollectNumber { get; set; }
        
        [DisplayName("Shop ID")]
        public string IdShop { get; set; }
        
        [DisplayName("Address")]
        public string Address { get; set; }
        
        [DisplayName("Amount")]
        public string Amount { get; set; }

        [DisplayName("Agent")]
        public String Agent { get; set; }

        
        [DisplayName("Status")]
        public string Status { get; set; }
        
        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }
        
        [DisplayName("Expire Date")]
        public DateTime ExprireDate { get; set; }
        
        [DisplayName("Collected Date")]
        public DateTime CollectedDate { get; set; }
    }


    #endregion MODELS

    #region SERVICES    

    public class StoreManagerBalanceSelect
    {
        public string ManagerName{ get; set; }
        public string ManagerPhone { get; set; }

        public int Id { get; set; }
        public string Area { get; set; }
        public string IdShop { get; set; }
        public string Address { get; set; }
        public int Balance { get; set; }
        public bool Selected { get; set; }
    }
    #endregion SERVICES

}