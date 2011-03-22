using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPDataAccess;

namespace MoneyPacificService.BUS
{
    public class StoreManagerBUS
    {
        internal static int GetTotalAmount(Guid userId)
        {
            List<StoreUser> lstStoreUser = StoreUserDAO.GetList(userId);

            int iTotalAmount = 0;
            foreach (StoreUser su in lstStoreUser)
            {
                iTotalAmount += StoreUserBUS.GetTotalAmount(su.UserId);
            }

            return iTotalAmount;
        }

        internal static bool Validate(string phoneNumber, string pinstore)
        {
            bool bResult = false;
            if (StoreManagerDAO.IsExist(phoneNumber))
            {
                StoreManager existManager = StoreManagerDAO.GetObject(phoneNumber);
                List<StoreUser> lstUser = StoreUserDAO.GetArray(existManager.UserId).ToList<StoreUser>();
                foreach (StoreUser u in lstUser)
                {
                    bResult = bResult || (u.PINStore.Trim() == pinstore.Trim());
                }
            }
            return bResult;
        }

        internal static bool UnLock(string phoneManager, string pinstore)
        {
            bool bResult = false;
            if (StoreManagerDAO.IsExist(phoneManager))
            {
                StoreManager existManager = StoreManagerDAO.GetObject(phoneManager);
                List<StoreUser> lstUser = StoreUserDAO.GetArray(existManager.UserId).ToList<StoreUser>();
                foreach (StoreUser u in lstUser)
                {
                    if (u.PINStore == pinstore)
                    {
                        /// LOCK all store have the same PINSTORE
                        bResult = bResult | StoreUserDAO.UnLock(u.UserId);
                    }
                }
            }
            return bResult;
        }

        internal static bool Lock(string phoneNumber, string pinstore)
        {
            bool bResult = false;
            if (StoreManagerDAO.IsExist(phoneNumber))
            {
                StoreManager existManager = StoreManagerDAO.GetObject(phoneNumber);
                List<StoreUser> lstUser = StoreUserDAO.GetArray(existManager.UserId).ToList<StoreUser>();
                foreach (StoreUser u in lstUser)
                {
                    if (u.PINStore == pinstore)
                    {
                        /// LOCK all store have the same PINSTORE
                        bResult = bResult | StoreUserDAO.Lock(u.UserId);
                    }
                }
            }
            return bResult;

        }
        
        internal static int GetTotalCollectedAmount(Guid managerId)
        {
            int statusId = CollectionStateBUS.GetId("Collected");
            List<Collection> lstCollection = CollectionDAO.GetList(managerId, statusId);

            int iResult = 0;

            foreach (Collection cl in lstCollection)
            {
                //if (cl.Amount == null) cl.Amount = 0;
                iResult += (cl.Amount==null?0:(int)cl.Amount);
            }

            return iResult;
        }
    }
}   