using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P4_MoneyPacificSite.Models.DAO
{
    public class StoreDAO
    {
        public static Store getTestStore()
        {
            MoneyPacificEntities mpdb = new MoneyPacificEntities();
            Store store = mpdb.Stores.First<Store>();
            mpdb.Connection.Close();
            return store;
        }
    }
}