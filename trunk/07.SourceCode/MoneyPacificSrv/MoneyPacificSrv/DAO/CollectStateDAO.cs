using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv.DAO
{
    public class CollectStateDAO
    {
        public static int GetId(string nameState)
        {
            DBMoneyPacificDataContext db = new DBMoneyPacificDataContext();
            int id = (int)db.CollectStates
                .Where(c => c.Name.Trim() == nameState.Trim())
                .Single<CollectState>().Id;
            db.Connection.Close();
            return id;
        }
    }
}