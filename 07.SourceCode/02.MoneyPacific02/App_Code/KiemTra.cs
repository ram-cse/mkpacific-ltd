using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: If you change the class name "KiemTra" here, you must also update the reference to "KiemTra" in Web.config.
public class KiemTra : IKiemTra
{
	public string KiemTraGiaTri(string chuoiNhap)
	{
        return "kiem tra " + chuoiNhap;
	}

    #region IKiemTra Members

    string IKiemTra.KiemTraGiaTri(string chuoiNhap)
    {
        throw new NotImplementedException();
    }

    #endregion
}
