using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{
    public partial class PartPacificCode
    {
        public void CopyFrom(PartPacificCode entity)
        {
            this.CateId = entity.CateId;
            this.Comment = entity.Comment;
            this.CustomerId = entity.CustomerId;
            this.LastTransaction = entity.LastTransaction;
            this.PartCodeNumber = entity.PartCodeNumber;
            this.StoreUserId = entity.StoreUserId;           

        }
    }
}
