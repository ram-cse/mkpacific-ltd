using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSite.Models.DAO;

namespace MoneyPacificSite.Models.BUS
{
    public class AgentStateBUS
    {
        internal static List<AgentState> GetList()
        {
            return AgentStateDAO.GetArray().ToList();
        }
    }
}