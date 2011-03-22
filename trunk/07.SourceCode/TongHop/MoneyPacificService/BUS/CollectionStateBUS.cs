using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPDataAccess;

namespace MoneyPacificService.BUS
{
    public class CollectionStateBUS
    {
        internal static int GetId(string nameState)
        {
            CollectionState existState = CollectionStateDAO.GetObject(nameState);
            if (existState != null)
            {
                return existState.Id;
            }
            else
            {
                throw new Exception("MKPacific: Not exist this collectionstate: " + nameState);
            }
        }

        internal static CollectionState GetObject(int id)
        {
            return CollectionStateDAO.GetObject(id);
        }
    }
}