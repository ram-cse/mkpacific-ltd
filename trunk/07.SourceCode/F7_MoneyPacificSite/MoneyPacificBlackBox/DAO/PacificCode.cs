using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificBlackBox.DAO
{
    public partial class PacificCode
    {
        internal void CopyFrom(PacificCode entity)
        {
            this.ActualAmount = entity.ActualAmount;
            this.CodeNumber = entity.CodeNumber;
            this.Comment = entity.Comment;
            this.CreateDate = entity.CreateDate;
            this.ExpireDate = entity.ExpireDate;
            this.InitialAmount = entity.InitialAmount;
            this.LastDate = entity.LastDate;
            this.LastTransaction = entity.LastTransaction;
            this.StatusId = entity.StatusId;            
        }
    }
}