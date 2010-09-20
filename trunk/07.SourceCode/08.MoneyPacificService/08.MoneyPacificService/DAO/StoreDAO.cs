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
            // Kiểm tra xem có Store nào tồn tại với Phone đã cho hay không?
            return mpdb.Stores.Any(l => l.Phone == senderStore.Phone);
            //bool bExist = mpdb.Stores.Where(l => l.Phone == senderStore.Phone).Any();
            //return bExist;
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
    }
}