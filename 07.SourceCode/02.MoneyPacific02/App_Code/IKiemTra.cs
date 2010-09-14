using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: If you change the interface name "IKiemTra" here, you must also update the reference to "IKiemTra" in Web.config.
[ServiceContract]
public interface IKiemTra
{
	[OperationContract]
    string KiemTraGiaTri(string chuoiNhap);
}
