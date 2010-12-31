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
        PacificCode NewPacificCode(int amount);

        [OperationContract]
        bool IsPossible(string codeNumber);
        
        [OperationContract]
        string ChangeCode(int codeNumber);

        [OperationContract]
        PacificCode GetValue(string partCodeNumber);

        [OperationContract]
        PacificCode MakePayment(string codeNumber, int amount);

        [OperationContract]
        bool MakePaymentTo(string codeNumber, string partCodeNumber, int amount);

        [OperationContract]
        PacificCode Merge(string[] arrCodeNumber);
    }


}
