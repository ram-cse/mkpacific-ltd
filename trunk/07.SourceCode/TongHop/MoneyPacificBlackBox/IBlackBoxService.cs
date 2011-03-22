using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MoneyPacificBlackBox.DAO;
using MoneyPacificBlackBox.DTO;

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
        bool IsExist(string codeNumber);
        
        [OperationContract]
        bool IsExistPart(string partCodeNumber);                

        [OperationContract]
        PacificCodeViewModel GetPacificCodeViewModel(string partCodeNumber);

        [OperationContract]
        PacificCodeViewModel[] GetArrayPacificCodeViewModel(string[] arrPartCodeNumber);

        [OperationContract]
        string ChangeCode(string codeNumber);

        [OperationContract]
        int GetValue(string partCodeNumber);

        [OperationContract]
        double GetInitialAmount(string partCodeNumber);

        [OperationContract]
        DateTime GetExpireDate(string partCodeNumber);

        [OperationContract]
        string MakePayment(string codeNumber, int amount);

        [OperationContract]
        bool MakePaymentTo(string codeNumber, string partCodeNumber, int amount);

        [OperationContract]
        string Merge(string[] arrCodeNumber);
    }


}
