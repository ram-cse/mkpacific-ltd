using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F5_MoneyPacificSite.Models.DAO
{
    public class CollectMoneyDAO
    {

        internal static bool IsExist(string collectNumber)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            bool bResult = db.CollectMoneys
                .Where(c => c.CollectNumber.Trim() == collectNumber.Trim())
                .Any();
            db.Connection.Close();
            return bResult;
        }

        internal static void AddItem(CollectMoney newCollectMoney)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();

            db.CollectMoneys.AddObject(newCollectMoney);
            db.SaveChanges();
            db.Connection.Close();
        }

        internal static CollectMoney[] GetList(int storeManagerId)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            CollectMoney[] arrResult = db.CollectMoneys
                .Where(c => c.StoreManagerId == storeManagerId).ToArray();
            db.Connection.Close();
            return arrResult;
        }

        internal static CollectMoney[] GetListStatusId(int statusId)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            CollectMoney[] arrResult = db.CollectMoneys
                .Include("StoreManager")
                .Include("Agent")
                .Include("CollectState")
                .Where(c => c.StatusId== statusId).ToArray();
            db.Connection.Close();
            return arrResult;
        }
    }
}