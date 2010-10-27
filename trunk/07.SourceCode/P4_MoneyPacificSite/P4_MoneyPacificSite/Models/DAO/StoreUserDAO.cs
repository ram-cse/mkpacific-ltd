using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P4_MoneyPacificSite.Models.DAO
{
    public class StoreUserDAO
    {
        public static StoreUser getTestStoreUser()
        {
            MoneyPacificEntities mpdb = new MoneyPacificEntities();
            StoreUser store = mpdb.StoreUsers.First<StoreUser>();
            mpdb.Connection.Close();
            return store;
        }
    }
}