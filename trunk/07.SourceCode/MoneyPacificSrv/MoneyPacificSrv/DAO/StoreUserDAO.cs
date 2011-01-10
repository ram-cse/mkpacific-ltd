using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv.DAO
{
    public class StoreUserDAO
    {
        // private static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

        internal static bool CheckPassword(StoreUser senderStore)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            bool bResult = mpdb.StoreUsers.Where(l => (l.Phone == senderStore.Phone
                 && l.PINStore == senderStore.PINStore)).Any();
            mpdb.Connection.Close();
            return bResult;

        }

        internal static bool IsExist(StoreUser senderStore)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            bool bResult = mpdb.StoreUsers.Any(l => l.Phone.Trim() == senderStore.Phone.Trim());
            mpdb.Connection.Close();
            return bResult;
        }

        internal static StoreUser GetStoreUser(string storePhone, string PINStore)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            StoreUser existStore = mpdb.StoreUsers
                .Where(s => s.Phone.Trim() == storePhone.Trim() && s.PINStore == PINStore)
                .FirstOrDefault();
            mpdb.Connection.Close();
            return existStore;
        }

        internal static void updateAfterInsertNewCode(PacificCode newPacificCode)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            // GET
            StoreUser existStore = mpdb.StoreUsers.Where(s => s.Id == newPacificCode.StoreId).Single<StoreUser>();

            // EXEC
            if (existStore != null)
            {
                if (existStore.NumberSales == null)
                {
                    existStore.NumberSales = 1;
                }
                else
                {
                    existStore.NumberSales++;
                }

                if (existStore.TotalSales == null)
                {
                    existStore.TotalSales = newPacificCode.ActualAmount;
                }
                else
                {
                    existStore.TotalSales += newPacificCode.ActualAmount;
                }
                // SAVE
                mpdb.SubmitChanges();
            }

            mpdb.Connection.Close();
        }

        internal static StoreUser[] GetArray(int managerId)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            StoreUser[] lstUser = mpdb.StoreUsers.Where(s => s.ManagerId == managerId).ToArray();
            mpdb.Connection.Close();
            return lstUser;
        }

        internal static bool IsExist(string sPhone)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            bool bResult = mpdb.StoreUsers.Any(l => l.Phone.Trim() == sPhone.Trim());
            mpdb.Connection.Close();
            return bResult;
        }

        internal static StoreUser GetItem(string sPhone)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            StoreUser result = mpdb.StoreUsers
                .Where(l => l.Phone.Trim() == sPhone.Trim())
                .Single<StoreUser>();

            mpdb.Connection.Close();
            return result;
        }

        internal static bool Lock(int storeId)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            StoreUser exitStore = mpdb.StoreUsers
                .Where(l => l.Id == storeId)
                .Single<StoreUser>();
            
            /// LOCK
            exitStore.Enable = false;
            /// 

            mpdb.SubmitChanges();
            mpdb.Connection.Close();
            return true;            
        }

        internal static StoreUser GetItem(int storeId)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            StoreUser exitStore = mpdb.StoreUsers
                .Where(l => l.Id == storeId)
                .Single<StoreUser>();
            mpdb.Connection.Close();
            return exitStore;            
        }

        internal static bool UnLock(int storeId)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            StoreUser exitStore = mpdb.StoreUsers
                .Where(l => l.Id == storeId)
                .Single<StoreUser>();

            /// UNLOCK
            exitStore.Enable = true;
            ///

            mpdb.SubmitChanges();
            mpdb.Connection.Close();
            return true;
        }

        /// <summary>
        /// Lấy tất cả các PacificCode được mua bởi StoreUser này, 
        /// ở trong tháng. Tính tổng tất cả InitialAmount 
        /// </summary>        
        internal static int GetTotalAmount(int storeId)
        {
            DBMoneyPacificDataContext db = new DBMoneyPacificDataContext();
            int iTotalAmount = 0;

            //iTotalAmount = (from p in db.PacificCodes
            //                where p.StoreId == storeId
            //                select (int)p.InitialAmount).DefaultIfEmpty().Sum();

            List<PacificCode> lstPacificCode = PacificCodeDAO.GetList(storeId);
            foreach (PacificCode p in lstPacificCode)
            {
                if (p.InitialAmount == null) p.InitialAmount = 0;
                iTotalAmount += (int)p.InitialAmount;
            }

            db.Connection.Close();
            return iTotalAmount;
        }
    }
}