using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;
using MoneyPacificSrv.DAO;

namespace MoneyPacificSrv.BUS
{
    public class AgentBUS
    {
        internal static Agent GetItem(int id)
        {
            return AgentDAO.GetItem(id);
        }
    }
}