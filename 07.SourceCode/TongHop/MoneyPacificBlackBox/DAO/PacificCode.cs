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
            this.CodeNumber = entity.CodeNumber;
            this.ActualAmount = entity.ActualAmount;                        
            this.InitialAmount = entity.InitialAmount;
            
            this.Comment = entity.Comment;
            
            this.CreateDate = entity.CreateDate;
            this.ExpireDate = entity.ExpireDate;
            this.LastDate = entity.LastDate;
            
            this.LastTransaction = entity.LastTransaction;
            this.StatusId = entity.StatusId;            
        }
    }
}