using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DAO;

namespace MoneyPacificSrv.BUS
{
    public class CollectStateBUS
    {

        internal static int GetId(string nameState)
        {
            return CollectStateDAO.GetId(nameState);
        }
    }
}