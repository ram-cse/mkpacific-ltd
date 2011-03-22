using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPDataAccess;

namespace MoneyPacificService.BUS
{
    public class CollectionBUS
    {
        internal static bool CollectAmountMoney(string collectNumber, int iAmount)
        {
            Collection existCollection = CollectionDAO.GetObject(collectNumber);
            existCollection.Amount = iAmount;
            existCollection.StatusId = CollectionStateBUS.GetId("Collected");
            existCollection.CollectDate = DateTime.Today.Date;

            return CollectionDAO.Update(existCollection);

        }
    }
}