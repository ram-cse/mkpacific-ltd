using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSite.Models.DAO;

namespace MoneyPacificSite.Models.BUS
{
    public class CollectStateBUS
    {
        internal static int GetId(string nameState)
        {
            return CollectStateDAO.GetId(nameState);
        }
    }
}