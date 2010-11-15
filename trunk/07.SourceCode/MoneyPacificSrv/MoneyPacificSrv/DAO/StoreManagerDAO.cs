using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv.DAO
{
    public class StoreManagerDAO
    {
        internal static StoreManager GetItem(string sPhone)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            StoreManager existStore = mpdb.StoreManagers.
                Where(s => s.ManagerPhone.Trim() == sPhone.Trim()).Single<StoreManager>();
            mpdb.Connection.Close();
            return existStore;
        }

        internal static bool IsExist(string sPhone)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            bool bResult = mpdb.StoreManagers.Where(s => s.ManagerPhone.Trim() == sPhone.Trim()).Any();
            mpdb.Connection.Close();
            return bResult;            
        }

        internal static StoreManager GetItem(int managerId)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            StoreManager existStore = mpdb.StoreManagers.
                Where(s => s.Id == managerId).Single<StoreManager>();
            mpdb.Connection.Close();
            return existStore;            
        }

        //internal static bool Validate(string phone, string pinstore)
        //{
        //}
    }
}