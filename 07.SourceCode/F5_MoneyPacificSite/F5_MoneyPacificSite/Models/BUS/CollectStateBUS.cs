using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using F5_MoneyPacificSite.Models.DAO;

namespace F5_MoneyPacificSite.Models.BUS
{
    public class CollectStateBUS
    {
        internal static int GetId(string nameState)
        {
            return CollectStateDAO.GetId(nameState);
        }
    }
}