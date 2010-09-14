using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _03.MoneyPacific._03
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICalcService" in both code and config file together.
    [ServiceContract]
    public interface ICalcService
    {
        [OperationContract(Name="AddInt")]
        int AddInt(int x, int y);

        [OperationContract(Name = "AddDouble")]
        double  AddDouble(double x, double y);

        
    }
}
