using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MoneyPacificService.Util;

namespace MoneyPacificService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMain
    {

        [OperationContract]
        string SendMessage(string smsContent);

        [OperationContract]
        PaymentModel MakePayment(List<string> LstCodeNumber, int Amount);
        // TODO: Add your service operations here
    }

}
