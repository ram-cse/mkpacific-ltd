using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace F5_MoneyPacificSite.Models.DAO
{
    public class AgentDAO
    {
        internal static List<Agent> GetList()
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            List<Agent> lstAgent = db.Agents.ToList();
            db.Connection.Close();
            return lstAgent;
         }

    }
}