using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MoneyPacificService.DTO;

namespace MoneyPacificService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Main : IMain
    {
        public string SendMessage(string smsContent)
        {
            // return (new BlackBoxServiceClient()).NewPacificCode(2000000);
            // return(new BlackBoxServiceClient()).GetExpireDate("4313963400900071").ToShortDateString();
            // return (new BlackBoxServiceClient()).GetValue("4313963400900071").ToString();
            return MoneyPacific.SendMessage(smsContent);
        }

        public PaymentModel MakePayment(List<string> lstCodeNumber, int amount)
        {
            return MoneyPacific.MakePayment(lstCodeNumber, amount);            
        }
    }
}
