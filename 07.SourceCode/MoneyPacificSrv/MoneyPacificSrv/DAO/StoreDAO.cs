using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv.DAO
{
    public class StoreDAO
    {
        // private static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

        internal static bool checkPassword(DTO.Store senderStore)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            bool bResult = mpdb.Stores.Where(l => (l.Phone == senderStore.Phone
                 && l.PassStore == senderStore.PassStore)).Any();
            mpdb.Connection.Close();
            return bResult;

        }

        internal static bool checkExist(Store senderStore)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            bool bResult = mpdb.Stores.Any(l => l.Phone == senderStore.Phone);
            mpdb.Connection.Close();
            return bResult;
        }

        internal static Store getStore(string storePhone, string passStore)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            Store existStore = mpdb.Stores.Where(s => s.Phone == storePhone && s.PassStore == passStore).FirstOrDefault();
            mpdb.Connection.Close();
            return existStore;
        }

        internal static void updateAfterInsertNewCode(PacificCode newPacificCode)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            // GET
            Store existStore = mpdb.Stores.Where(s => s.ID == newPacificCode.StoreID).Single<Store>();

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