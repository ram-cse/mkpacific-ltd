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
            bool bResult = mpdb.StoreUsers.Any(l => l.Phone == senderStore.Phone);
            mpdb.Connection.Close();
            return bResult;
        }

        internal static StoreUser GetStoreUser(string storePhone, string PINStore)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            StoreUser existStore = mpdb.StoreUsers.Where(s => s.Phone.Trim() == storePhone.Trim() && s.PINStore == PINStore).FirstOrDefault();
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

        internal static List<StoreUser> GetList(int managerId)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            List<StoreUser> lstUser = mpdb.StoreUsers.Where(s => s.ManagerId == managerId).ToList<StoreUser>();
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
    }
}