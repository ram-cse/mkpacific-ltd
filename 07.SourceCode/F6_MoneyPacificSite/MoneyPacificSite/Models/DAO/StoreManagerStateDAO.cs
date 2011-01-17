using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSite.Models.DAO
{
    public class StoreManagerStateDAO
    {
        public static int GetId(string codeState)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            StoreManagerState state = db.StoreManagerStates.Where
                (s => s.Code.Trim() == codeState.Trim()).Single<StoreManagerState>();
            return state.Id;
        }

        internal static string GetCode(int Id)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            string result = db.StoreManagerStates.Where(s => s.Id == Id)
                .Single<StoreManagerState>().Code;
            db.Connection.Close();
            return result;
        }

        internal static StoreManagerState[] GetArray()
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            StoreManagerState[] result = db.StoreManagerStates.ToArray();
            db.Connection.Close();
            return result;
        }
    }
}