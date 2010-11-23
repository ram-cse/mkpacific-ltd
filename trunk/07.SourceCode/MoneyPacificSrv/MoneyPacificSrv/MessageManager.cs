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
            
            new MPMessageDTO("CHECK_VALUE_DETAIL_SUCCESSFUL", "Ma PacificCode {0} co gia tri hien tai la {1}. Va co han su dung den ngay{2}."),
            
            new MPMessageDTO("GENERATE_SUCCESSFUL", "Ban vua mua mot PacificCode: {0} co gia tri  {1} VND. va han su dung de ngay {2}" ),

            new MPMessageDTO("WRONG_PASSWORD", "Sai mat khau"),
          
            new MPMessageDTO("INVALID_AMOUNT", "Khong co loai tai khoang: {0} VND"),
            
            new MPMessageDTO("INVALID_AMOUNT_CONFIRM", "So tien va Xac nhan so tien phai trung khop."),
            
            new MPMessageDTO("INVALID_PHONE", "So dien thoai nguoi nhan khong co that"),
            
            new MPMessageDTO("BLACK_LIST", "BLACK LIST!.. "),

            new MPMessageDTO("CUSTOMER_IN_BLACK_LIST", "So Phone KH trong BLACK LIST, khong the mua!.. "),

            new MPMessageDTO("BE_BLACK_LIST", "So Phone nay da dua vao BLACK LIST!.. "),
            
            new MPMessageDTO("NOT_EXIST_PACIFICCODE", "MoneyPacific: Xin loi quy khach, ma nay khong co hieu luc."),

            new MPMessageDTO("WILL_BE_LOCKED", "MoneyPacific: Xin loi quy khach, ma nay khong co hieu luc, kiem tra sai lan nua so phone cua ban se bi KHOA!"),
            
            new MPMessageDTO("BE_LOCKED", "MoneyPacific: Qui khach da tao su nghi ngo, So Phone cua ban bi KHOA!"),

            new MPMessageDTO("NOT_EXIST_STORE", "MoneyPacific: Yeu cau bi tu choi."),

            new MPMessageDTO("LOCKED_CUSTOMER", "KH nay da bi khoa! "),
            new MPMessageDTO("MAKE_PAYMENT_UNSUCCESS", "Thanh toan khong thanh cong"),
            new MPMessageDTO("MAKE_PAYMENT_SUCCESS", "Thanh toan thanh cong"),

            new MPMessageDTO("MPBAL_GET_COLLECT_CODE_ERROR", "MPBAL-PINSTORE sai hoac ban khong co quyen"),
            
            new MPMessageDTO("MPDIS_DISABLE_ERROR", "MPDIS-PINSTORE sai hoac ban khong co quyen."),
            new MPMessageDTO("MPDIS_DISABLE_SUCCESSFULL", "MPDIS-Disable thanh cong."),            

            new MPMessageDTO("MPENA_ENABLE_ERROR", "MPENA-PINSTORE sai hoac ban khong co quyen."),
            new MPMessageDTO("MPENA_ENABLE_SUCCESSFULL", "MPENA-Enable thanh cong."),
            
            
            new MPMessageDTO("STORE_IS_DISABLE", "STORE nang trong tinh trang DISABLE."),

            new MPMessageDTO("MPCOL_GET_COLLECT_CODE_ERROR", "MPCOL - Ban khong co quyen truy cap vao lenh nay hoac la bi sai ma CollectCode. Neu tiep tuc so phone ban se bi khoa."),
            new MPMessageDTO("MPCOL_SUCCESSFULL", "MPCOL - Thuc hien thanh cong! Vui dua so tien {0} VND cho ong/ba {1} co IdNumber {2}. Kiem tra so IdNumber cua nguoi nhan."),
            new MPMessageDTO("MPCOL_NO_PERMISSION", "MPCOL - Ban khong co quyen! Neu tiep tuc, so dien thoai ban se bi khoa!"),
            new MPMessageDTO("MPCOL_WRONG_COLLECT_NUMBER", "MPCOL - Sai Collect Code!. Neu sai lien tiep 3 lan SDT cua ban se bi khoa."),
            new MPMessageDTO("MPCOL_COLLECTED", "MPCOL - CollectCode {0}: Da duoc thanh toan co gia tri {1} VND vao ngay {2}, nguoi thu la ong/ba: {3} co IdNumber la: {4}!")
            //new MPMessageDTO("MPCOL_EXPIRE", "MPCOL - CollectCode nay da het han ") // Khong su dung-> dung chung MPCOL_WRONG_COLLECT_NUMBER
            
        };

        internal static string GetValue(string sName, string[] args)
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

            for (int i = 0; i < args.Count(); i++)
            {
                string sOldString = "{" + i + "}";
                sResult = sResult.Replace(sOldString, args[i]);
            }

            return sResult;
        }
        
        internal static string GetValue(string sName)
        {
            return GetValue(sName, new string[]{});
        }

        internal static string GetValue(string sName, string arg0)
        {
            return GetValue(sName, new string[] { arg0 });
        }

        internal static string GetValue(string sName, string arg0, string arg1)
        {
            return GetValue(sName, new string[] { arg0, arg1 });
        }

        internal static string GetValue(string sName, string arg0, string arg1, string arg2)
        {
            return GetValue(sName, new string[] { arg0, arg1, arg2 });
        }

        internal static string GetValue(string sName, string arg0, string arg1, string arg2, string arg3)
        {
            return GetValue(sName, new string[] { arg0, arg1, arg2, arg3 });
        }

        internal static string GetValue(string sName, string arg0, string arg1, string arg2, string arg3, string arg4)
        {
            return GetValue(sName, new string[] { arg0, arg1, arg2, arg3, arg4 });
        }


    }
}