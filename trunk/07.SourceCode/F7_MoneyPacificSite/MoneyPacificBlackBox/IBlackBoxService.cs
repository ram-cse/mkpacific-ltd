using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MoneyPacificBlackBox.DAO;

namespace MoneyPacificBlackBox
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBlackBoxService
    {
        [OperationContract]
        string NewPacificCode(int amount);

        [OperationContract]
        bool IsPossible(string codeNumber);
        
        [OperationContract]
        string ChangeCode(int codeNumber);

        [OperationContract]
        int GetValue(string partCodeNumber);

        [OperationContract]
        string MakePayment(string codeNumber, int amount);

        [OperationContract]
        bool MakePaymentTo(string codeNumber, string partCodeNumber, int amount);

        [OperationContract]
        string Merge(string[] arrCodeNumber);
    }


}
