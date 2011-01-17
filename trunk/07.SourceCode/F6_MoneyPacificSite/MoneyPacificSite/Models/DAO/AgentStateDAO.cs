using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSite.Models.DAO
{
    public class AgentStateDAO
    {
        internal static AgentState[] GetArray()
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            AgentState[] result = db.AgentStates.ToArray();
            db.Connection.Close();
            return result;
        }
    }
}