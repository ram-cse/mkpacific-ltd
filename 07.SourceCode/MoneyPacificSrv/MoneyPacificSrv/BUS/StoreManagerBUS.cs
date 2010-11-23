using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;
using MoneyPacificSrv.DAO;

namespace MoneyPacificSrv.BUS
{
    public class StoreManagerBUS
    {
        internal static StoreManager GetItem(string phone)
        {
            return StoreManagerDAO.GetItem(phone);
        }

        internal static bool IsExist(string phone)
        {
            return StoreManagerDAO.IsExist(phone);
        }

        internal static StoreManager GetItem(int managerId)
        {
            return StoreManagerDAO.GetItem(managerId);
        }

        internal static bool Validate(string phoneManager, string pinstore)
        {
            
            bool bResult = false;            
            if (StoreManagerDAO.IsExist(phoneManager))
            {
                StoreManager existManager = StoreManagerDAO.GetItem(phoneManager);
                List<StoreUser> lstUser = StoreUserDAO.GetArray(existManager.Id).ToList<StoreUser>();
                foreach (StoreUser u in lstUser)
                {
                    bResult = bResult || (u.PINStore.Trim() == pinstore.Trim());
                }
            }
            return bResult;
        }

        internal static bool Lock(string phoneManager, string pintore)
        {
            bool bResult = false;
            if (StoreManagerDAO.IsExist(phoneManager))
            {
                StoreManager existManager = StoreManagerDAO.GetItem(phoneManager);
                List<StoreUser> lstUser = StoreUserDAO.GetArray(existManager.Id).ToList<StoreUser>();
                foreach (StoreUser u in lstUser)
                {
                    if (u.PINStore == pintore)
                    {
                        /// LOCK all store have the same PINSTORE
                        bResult = bResult | StoreUserDAO.Lock(u.Id);
                    }
                }
            }
            return bResult;
        }

        internal static bool UnLock(string phoneManager, string pintore)
        {
            bool bResult = false;
            if (StoreManagerDAO.IsExist(phoneManager))
            {
                StoreManager existManager = StoreManagerDAO.GetItem(phoneManager);
                List<StoreUser> lstUser = StoreUserDAO.GetArray(existManager.Id).ToList<StoreUser>();
                foreach (StoreUser u in lstUser)
                {
                    if (u.PINStore == pintore)
                    {
                        /// LOCK all store have the same PINSTORE
                        bResult = bResult | StoreUserDAO.UnLock(u.Id);
                    }
                }
            }
            return bResult;
        }

        /// <summary>
        /// Giong ben MoneyPacificSite
        /// </summary>
        internal static int GetTotalAmount(int ManagerId)
        {
            StoreUser[] lstStoreUser = StoreUserDAO.GetArray(ManagerId);
            int iTotal = 0;

            foreach (StoreUser u in lstStoreUser)
            {
                iTotal += StoreUserDAO.GetTotalAmount(u.Id);
            }
            return iTotal;

        }

        internal static int GetTotalCollectedAmount(int storeManagerId)
        {
            int iStatusId = CollectStateDAO.GetId("Collected");
            List<CollectMoney> lstCollectMoney = CollectMoneyDAO.GetList(storeManagerId,iStatusId).ToList<CollectMoney>();
            int iResult = 0;
            foreach (CollectMoney cm in lstCollectMoney)
            {
                if (cm.Amount == null) cm.Amount = 0;
                iResult += (int)cm.Amount;
            }
            return iResult;
        }
    }
}