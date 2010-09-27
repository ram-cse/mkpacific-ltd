using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _08.MoneyPacificService.DAO;

namespace _08.MoneyPacificService.BUS
{
    public class TransactionBUS
    {

        internal static void AddNew(DTO.PacificCode newSuccessPacificCode)
        {
            TransactionDAO.AddNew(newSuccessPacificCode);
        }
    }
}