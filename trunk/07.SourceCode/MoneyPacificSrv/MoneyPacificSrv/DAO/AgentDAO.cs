using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv.DAO
{
    public class AgentDAO
    {
        internal static Agent GetItem(int id)
        {
            DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();
            Agent existAgent = mpdb.Agents.Where(a => a.Id == id).SingleOrDefault<Agent>();
            mpdb.Connection.Close();
            return existAgent;
        }
    }
}