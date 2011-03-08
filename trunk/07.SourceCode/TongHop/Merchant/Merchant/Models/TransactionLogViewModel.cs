using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchant.Models
{
    public static class TransactionLogViewModel
    {
        public static MPWebmasterEntities db = new MPWebmasterEntities();

        public static void AddLog(string content, DateTime now)
        {
            HTransaction log  = new HTransaction();
            log.Content = content;
            log.Date = now;
            db.HTransactions.AddObject(log);
            db.SaveChanges();
   
        }
        
    }
}