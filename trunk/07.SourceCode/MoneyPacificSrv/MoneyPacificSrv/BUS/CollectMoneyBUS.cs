using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;
using MoneyPacificSrv.DAO;

namespace MoneyPacificSrv.BUS
{
    public class CollectMoneyBUS
    {
        internal static bool CollectAmountMoney(string sCollectCode, int iAmount)
        {
            CollectMoney existCollectMoney = CollectMoneyDAO.GetItem(sCollectCode);
            
            existCollectMoney.Amount = iAmount;
            existCollectMoney.StatusId = CollectStateDAO.GetId("Collected");
            existCollectMoney.CollecteDate = DateTime.Now.Date;            
            
            return CollectMoneyDAO.Update(existCollectMoney);            
        }

        internal static CollectMoney GetItem(string sCollectCode)
        {
            return CollectMoneyDAO.GetItem(sCollectCode);
        }

        internal static bool IsExistProcessing(string sCollectCode)
        {
            int iStatusId = CollectStateDAO.GetId("Processing");
            return CollectMoneyDAO.IsExist(sCollectCode,iStatusId);
        }
    }
}