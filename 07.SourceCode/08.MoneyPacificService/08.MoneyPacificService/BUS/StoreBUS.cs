using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _08.MoneyPacificService.DTO;
using _08.MoneyPacificService.DAO;

namespace _08.MoneyPacificService.BUS
{
    public class StoreBUS
    {
        //public Money

        internal static bool checkExist(Store senderStore)
        {
            return StoreDAO.checkExist(senderStore);
        }
    }
}