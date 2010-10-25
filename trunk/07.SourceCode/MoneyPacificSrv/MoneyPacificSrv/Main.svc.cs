using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Main" in code, svc and config file together.
    public class Main : IMain
    {
        public string SendMessage(string smsContent)
        {
            return MoneyPacific.SendMessage(smsContent);
        }

        public PaymentModel MakePayment(List<string> LstCodeNumber, int Amount)
        {
            return MoneyPacific.MakePayment(LstCodeNumber, Amount);
        }
    }
}
