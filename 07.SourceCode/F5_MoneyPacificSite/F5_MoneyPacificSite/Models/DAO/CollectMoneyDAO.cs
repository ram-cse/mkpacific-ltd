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

        internal static CollectMoney GetItem(int storeManagerId, int iStatusId, DateTime expireDate)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            CollectMoney result = null;

            CollectMoney[] arrCM = db.CollectMoneys
                .Include("StoreManager")
                .Include("Agent")
                .Include("CollectState")
                .Where(c => c.StoreManagerId == storeManagerId
                && c.StatusId == iStatusId)
                .DefaultIfEmpty<CollectMoney>().ToArray();
            db.Connection.Close();

            //if (arrCM == null) arrCM = new CollectMoney[0];

            foreach (CollectMoney cm in arrCM)
            {
                if (cm != null)
                {
                    if (cm.ExpireDate == null)
                    {
                        cm.ExpireDate = DateTime.MinValue;
                    }

                    if (cm.ExpireDate.Value > expireDate)
                    {
                        result = cm;
                        break;
                    }
                }
            }
            return result;
        }

        internal static bool Update(CollectMoney updateCollectMoney, int agentId)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            
            CollectMoney existCollectMoney = db.CollectMoneys
                .Where(c => c.Id == updateCollectMoney.Id)
                .Single<CollectMoney>();

            existCollectMoney.CollectNumber = updateCollectMoney.CollectNumber;
            existCollectMoney.AgentId = agentId;

            existCollectMoney.CreateDate = DateTime.Now;
            existCollectMoney.ExpireDate = DateTime.Now.AddDays(1);


            db.SaveChanges();
            db.Connection.Close();
            
            return true;
        }
    }
}