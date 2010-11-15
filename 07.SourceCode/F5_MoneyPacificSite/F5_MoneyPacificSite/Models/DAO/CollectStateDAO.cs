using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F5_MoneyPacificSite.Models.DAO
{
    public class CollectStateDAO
    {
        public static int GetId(string nameState)
        {
            MoneyPacificEntities db= new MoneyPacificEntities();
            int id = (int)db.CollectStates
                .Where(c => c.Name.Trim() == nameState.Trim())
                .Single<CollectState>().Id;
            db.Connection.Close();
            return id;
        }
    }
}