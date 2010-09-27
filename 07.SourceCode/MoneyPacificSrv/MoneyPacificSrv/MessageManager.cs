using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSrv
{
    public class MessageManager
    {
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

        internal static string GenSuccessCreatePacificCodeMessage(DTO.PacificCode newPacificCode)
        {
            throw new NotImplementedException();
        }
    }
}