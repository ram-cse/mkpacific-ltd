using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;

namespace MoneyPacificSrv
{
    /// <summary>
    ///  TODO: Mỗi lần có 1 lời gọi là tạo kết nối tới DB, XML?
    ///  Quá phí
    /// </summary>

    public class MessageManager
    {
        internal static string sLanguage = "vn";
        internal static MPMessageDTO[] arrMessage = new MPMessageDTO[]{
            new MPMessageDTO("SAMPLE_MESSAGE", "Loi nhan vi du!... "),
            new MPMessageDTO("GENERATE_SUCCESSFUL", "Bạn đã mua thành công một PacificCode: "
                + "{0} có giá trị  {1} VND. Tài khoản này có giá trị đến ngày {3}" )
                
        };
        
        internal static string GenNotExistStoreMessage(string sPhoneNumber)
        {
            return (sPhoneNumber + "*" + "Yêu cầu bị từ chối! ");
        }

        internal static string GenErrorPasswordMessage()
        {
            return "Sai mật khẩu. ";
        }

        internal static string GenInvalidAmountMessage(int amountBuy)
        {
            return ("Không có tài khoản loại: " + amountBuy + " VND. ");
        }

        internal static string GenInvalidAmountConfirmMessage()
        {
            return ("Số tiền và Xác nhận số tiền phải trùng khớp. ");
        }

        internal static string GenInvalidPhoneMessage()
        {
            return ("Số điện thoại này không có thật. ");
        }

        internal static string GenSuccessCreatePacificCodeMessage(PacificCode newPacificCode)
        {
            string sCodeNumber = newPacificCode.CodeNumber;

            string sFormatCodeNumber = sCodeNumber.Substring(0, 4) + "-" + sCodeNumber.Substring(4, 4)
                + "-" + sCodeNumber.Substring(8, 4) + "-" + sCodeNumber.Substring(12, 4);
            
            string sResult = "Bạn đã mua thành công một PacificCode: " + sFormatCodeNumber
                + " có giá trị  " + newPacificCode.InitialAmount + " VND." 
                + " Tài khoản này có giá trị đến ngày " 
                + ((DateTime) newPacificCode.ExpireDate).ToShortDateString();
            
            return sResult;
        }

        internal static string getValue(string sName, string[] args)
        {
            string sResult = "Error message!...";
            
            // Find the messsage
            foreach (MPMessageDTO message in arrMessage)
            {
                if (message.name == sName)
                {
                    sResult = message.value;
                    break;
                }
            }

            // Replace the arguments by values in args
            for (int i = 0; i < args.Count(); i++)
            {
                // Ex: your moneypc is {0}
                // -> your moneypc is abcd efgh...

                string sOldString = "{" + i + "}";
                sResult = sResult.Replace(sOldString, args[i]);
            }

            return sResult;
        }

        internal static string getValue(string sName)
        {
            return getValue(sName, new string[]{});
        }

        internal static string getValue(string sName, string arg0)
        {
            return getValue(sName, new string[] { arg0 });
        }

        internal static string getValue(string sName, string arg0, string arg1)
        {
            return getValue(sName, new string[] { arg0, arg1 });
        }

        internal static string getValue(string sName, string arg0, string arg1, string arg2)
        {
            return getValue(sName, new string[] { arg0, arg1, arg2 });
        }

    }
}