using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv.DAO
{
    public class CollectMoneyDAO
    {
        internal static CollectMoney[] GetList(int storeManagerId)
        {
            DBMoneyPacificDataContext db = new DBMoneyPacificDataContext();
            CollectMoney[] arrResult = db.CollectMoneys
                .Where(c => c.StoreManagerId == storeManagerId).ToArray();
            db.Connection.Close();
            return arrResult;
        }

        internal static CollectMoney[] GetList(int storeManagerId, int statusId)
        {
            DBMoneyPacificDataContext db = new DBMoneyPacificDataContext();
            CollectMoney[] arrResult = db.CollectMoneys
                .Where(c => (c.StoreManagerId == storeManagerId)
                    && (c.StatusId == statusId))
                .ToArray();
            db.Connection.Close();
            return arrResult;
        }

        internal static CollectMoney[] GetListStatusId(int statusId)
        {
            DBMoneyPacificDataContext db = new DBMoneyPacificDataContext();
            CollectMoney[] arrResult = db.CollectMoneys                
                .Where(c => c.StatusId == statusId).ToArray();
            db.Connection.Close();
            return arrResult;
        }

        internal static bool Update(CollectMoney updateCollectMoney)
        {
            DBMoneyPacificDataContext db = new DBMoneyPacificDataContext();
            bool iResult = false;
            CollectMoney exitCollectMoney = db.CollectMoneys
                .Where(c => c.CollectNumber.Trim() == updateCollectMoney.CollectNumber.Trim())
                .Single<CollectMoney>();

            exitCollectMoney.Amount = updateCollectMoney.Amount;
            exitCollectMoney.CollecteDate = updateCollectMoney.CollecteDate;
            exitCollectMoney.StatusId = updateCollectMoney.StatusId;
            
            db.SubmitChanges();
            db.Connection.Close();

            iResult = true;
            return iResult;
        }

        //internal static bool Update(string sCollectCode)
        //{
        //    DBMoneyPacificDataContext db = new DBMoneyPacificDataContext();
        //    bool iResult = false;
        //    if (IsExist(sCollectCode))
        //    {
        //    }
        //    else
        //    {
        //        iResult = false;
        //    }
        //    db.Connection.Close();
        //    return iResult;
        //}

        internal static bool IsExist(string sCollectCode)
        {
            DBMoneyPacificDataContext db = new DBMoneyPacificDataContext();
            bool bResult = db.CollectMoneys
                .Where(c => c.CollectNumber.Trim() == sCollectCode.Trim()).Any();
            db.Connection.Close();
            return bResult;
        }

        internal static CollectMoney GetItem(string sCollectCode)
        {
            DBMoneyPacificDataContext db = new DBMoneyPacificDataContext();
            CollectMoney existCollectMoney = db.CollectMoneys                
                .Where(c => c.CollectNumber.Trim() == sCollectCode.Trim())
                .SingleOrDefault<CollectMoney>();
            db.Connection.Close();
            return existCollectMoney;
        }


        internal static bool IsExist(string sCollectCode, int iStatusId)
        {
            DBMoneyPacificDataContext db = new DBMoneyPacificDataContext();
            bool bResult = db.CollectMoneys
                .Where(c => c.CollectNumber.Trim() == sCollectCode.Trim()
                & (c.StatusId == iStatusId))
                .Any();
            db.Connection.Close();
            return bResult;
        }
    }
}