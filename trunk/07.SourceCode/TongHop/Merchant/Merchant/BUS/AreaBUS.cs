using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MPDataAccess;

namespace MoneyPacificSite.BUS
{
    public class AreaBUS
    {
        internal static Area GetObject(int id)
        {
            return AreaDAO.GetObject(id);
        }
    }
}