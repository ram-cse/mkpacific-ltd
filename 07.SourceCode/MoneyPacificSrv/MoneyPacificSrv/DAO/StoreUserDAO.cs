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

        internal static bool checkPassword(StoreUser senderStore)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            bool bResult = mpdb.StoreUsers.Where(l => (l.Phone == senderStore.Phone
                 && l.PassStore == senderStore.PassStore)).Any();
            mpdb.Connection.Close();
            return bResult;

        }

        internal static bool checkExist(StoreUser senderStore)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            bool bResult = mpdb.StoreUsers.Any(l => l.Phone == senderStore.Phone);
            mpdb.Connection.Close();
            return bResult;
        }

        internal static StoreUser getStoreUser(string storePhone, string passStore)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            StoreUser existStore = mpdb.StoreUsers.Where(s => s.Phone == storePhone && s.PassStore == passStore).FirstOrDefault();
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
    }
}