using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DAO;
using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv.BUS
{
    public class TransactionBUS
    {
        internal static void addNew(PacificCode newPacificCode)
        {
            TransactionDAO.AddNew(newPacificCode);
        }
    }
}