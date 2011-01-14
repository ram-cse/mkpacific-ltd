using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPDataAccess;

namespace MoneyPacificService.BUS
{
    public class StoreManagerBUS
    {
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
    }
}