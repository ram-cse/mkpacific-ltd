using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _08.MoneyPacificService.DTO;

namespace _08.MoneyPacificService.DAO
{
    public class StoreDAO
    {
        private static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

        internal static bool checkExist(DTO.Store senderStore)
        {
            // Kiểm tra xem có Store nào tồn tại.
            return mpdb.Stores.Any(l => l.Phone == senderStore.Phone);
            //return mpdb.Stores.Where(l => l.Phone == senderStore.Phone).Any();
            
        }

        internal static bool checkPassword(DTO.Store senderStore)
        {
            return mpdb.Stores.Where(l => (l.Phone == senderStore.Phone 
                 && l.PassStore == senderStore.PassStore)).Any();
            
        }

        internal static Store getStore(string sPhoneNumber)
        {
            return mpdb.Stores.Single(l => l.Phone == sPhoneNumber);
        }

        internal static void UpdateAfterInsertNewPCode(PacificCode newPacificCode)
        {

            // Lỗi: cần kiểm tra lại khi nào Store Null, nếu Null thì ko cho lưu
            Store existStore = mpdb.Stores.Where(s => s.ID == newPacificCode.StoreID).Single();
            
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
            }

            mpdb.SubmitChanges();
        }

        internal static Store getStore(string storePhone, string passStore)
        {
            Store existStore = mpdb.Stores.Where(s => s.Phone == storePhone && s.PassStore == passStore).FirstOrDefault();
            return existStore;
        }
    }
}