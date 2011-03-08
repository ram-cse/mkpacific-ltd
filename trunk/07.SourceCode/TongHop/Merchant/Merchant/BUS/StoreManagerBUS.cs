using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPDataAccess;

namespace MoneyPacificSite.BUS
{
    public class StoreManagerBUS
    {
        internal static StoreManager GetObject(Guid managerId)
        {
            return StoreManagerDAO.GetObject(managerId);
        }

        internal static int GetTotalLastMonthAmount(Guid managerId)
        {
            StoreUser[] lstStoreUser = StoreUserDAO.GetArray(managerId);
            int iTotal = 0;

            // TODO:
            //foreach (StoreUser u in lstStoreUser)
            //{
            //    iTotal += StoreUserDAO.GetTotalLastMonthAmount(u.Id);
            //}

            //int iTotalCollected = CollectMoneyBUS.GetCollectedAmount(managerId);

            //iTotal = iTotal - iTotalCollected;

            return iTotal;

        }

        internal static int GetTotalLastMonthTransaction(Guid managerId)
        {
            StoreUser[] lstStoreUser = StoreUserDAO.GetArray(managerId);
            int iCount = 0;

            // TODO:
            //foreach (StoreUser u in lstStoreUser)
            //{
            //    iCount += StoreUserDAO.GetTotalLastMonthTranSaction(u.UserId);
            //}
            return iCount;

        }

        // Ở lớp DAO => sửa lại
        //internal static int GetTotalLastMonthTranSaction(int storeUserId)
        //{
        //    MoneyPacificEntities db = new MoneyPacificEntities();

        //    int iCount = 0;
        //    iCount = (from p in db.PacificCodes
        //              where (p.StoreId == storeUserId
        //                     && ((DateTime)p.Date).Month == DateTime.Now.Month
        //                     && ((DateTime)p.Date).Year == DateTime.Now.Year)
        //              select p.Id).Count();

        //    db.Connection.Close();
        //    return iCount;
        //}


        internal static bool ChangeLocked(Guid userId)
        {
            StoreManager existSM = StoreManagerDAO.GetObject(userId);

            if (existSM.IsLocked == null)
            {
                existSM.IsLocked = false;
            }
            else
            {
                existSM.IsLocked = !existSM.IsLocked;
            }

            bool isLocked = (bool)existSM.IsLocked;

            StoreManagerDAO.Update(existSM);

            return isLocked;
        }
    }
}