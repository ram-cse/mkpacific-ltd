using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MPDataAccess;

namespace MoneyPacificSite.ViewModels
{
    #region MODELS
    public class AdminListAmountViewModel
    {
        public List<StoreManagerBalanceSelect> StoreManagers { get; set; }
        public List<Agent> Agents { get; set; }
        public int AgentIdSelected { get; set; }
    }
    #endregion MODELS

    #region SERVICES
    public class StoreManagerBalanceSelect
    {
        public string ManagerName { get; set; }
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