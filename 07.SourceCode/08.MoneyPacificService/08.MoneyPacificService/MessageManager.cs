using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _08.MoneyPacificService
{
    public class MessageManager
    {
        
        internal static string GenSucessCreatePacificCodeMessage(string sPacificCode,int amount)
        { 
            // Load từ tập tin XML, thay vào các biến giá trị
            // Tách chuỗi sPacificCode thành định dạng abcd-efgh-ijkm-mnop

            string sFormatPacificCode = sPacificCode.Substring(0, 4) + "-"
                + sPacificCode.Substring(4, 4) + "-" + sPacificCode.Substring(8, 4) + "-"
                + sPacificCode.Substring(12, 4);

            string sResult = "Bạn đã mua thành công một PacificCode: " + sFormatPacificCode
                + " có giá trị  " + amount + " VND. Tài khoản này có giá trị đến ";
            return sResult;                
        }

        internal static string GenNotExistStoreMessage(string sPhoneNumber)
        {
            return (sPhoneNumber + "*" + "Yêu cầu bị từ chối! ");
        }

        internal static string GenErrorPasswordStoreMessage()
        {
            return "Sai mật khẩu. ";
        }

        internal static string GenInValidAmountMessage(int amountBuy)
        {
            return ("Không có tài khoản loại: " + amountBuy + " VND. ");
        }

        internal static string GenInValidAmountConfirmMessage()
        {
            return ("Số tiền và Xác nhận số tiền phải trùng khớp. ");
        }

        internal static string GenInValidPhoneMessage()
        {
            return ("Số điện thoại này không có thật. ");
        }
    }
}