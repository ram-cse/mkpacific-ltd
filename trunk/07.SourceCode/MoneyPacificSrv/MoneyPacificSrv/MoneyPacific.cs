using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.Cmd;
using MoneyPacificSrv.Util;
using MoneyPacificSrv.DTO;
using MoneyPacificSrv.BUS;

using GeneratorPacificCode;

namespace MoneyPacificSrv
{
    public class MoneyPacific
    {
        internal static string SendMessage(string smsContent)
        {
            string smsResponse = "";
            string sCommand = "";


            // Phân tích để lấy command & arguments            
            smsContent = smsContent.Trim(' ');
            string[] arrArg = smsContent.Split('*');

            if (arrArg.Count() <= 1) return "Invalid Command";

            // Check BLACK LIST
            string senderPhone = arrArg[0];
            bool bLocked = false;

            if (Validator.isPhoneNumber(senderPhone))
            {
                if (CustomerBUS.isInBlackList(senderPhone))
                {
                    return "0*" + MessageManager.GetValue("BLACK_LIST");                 
                }

                bLocked = CustomerBUS.isLockedCustomer(senderPhone);
                if (bLocked)
                {
                    smsResponse = "0*" + MessageManager.GetValue("LOCKED_CUSTOMER");
                }

            }

            // The first argument alway is the phonenumber
            sCommand = arrArg[1];

            IMPCommand mpCommand;
            
            if (Validator.isPINStore(sCommand) && (arrArg.Length == 5))
            {
                sCommand = "BUY";
                bLocked = false; // cho phép mua
            }
            else if (Validator.isPacificCode(sCommand))
            {
                sCommand = "VALUE";                
            }

            if (bLocked) return smsResponse;

            // Create Command and Execute            
            if (sCommand == "BUY")
            {   
                mpCommand = new BuyPacificCodeCommand();
            }
            else if (sCommand == "VALUE")
            {
                mpCommand = new ValueDetailCommand();
            }
            else if (sCommand == "MPBAL")
            {
                mpCommand = new MPBALCommand();
            }
            else if (sCommand == "MPDAY")
            {
                mpCommand = new MPDAYCommand();
            }
            else if (sCommand == "MPDIS")
            {
                mpCommand = new MPDISCommand();
            }
            else if (sCommand == "MPENA")
            {
                mpCommand = new MPENACommand();
            }
            else
            {
                mpCommand = new UnderContructionCommand();
                smsResponse = sCommand + " - ";
            }

            // DTO.DBMoneyPacificDataContext storedb = new DTO.DBMoneyPacificDataContext();
            // List<Store> pCode = storedb.Stores.ToList<Store>();
            // return "finished!.. test..12..";

            smsResponse += mpCommand.Execute(arrArg);
            return smsResponse;
        }

        internal static PaymentModel MakePayment(List<string> LstCodeNumber, int Amount)
        {
            // TODO: 
            /* Lst CodeNumber phải đúng hết mới cho phép thanh toán
             * 
             * */

            // Kiểm tra

            bool isPossible = (LstCodeNumber.Count() > 0); // Bắt buộc phải có CodeNumber
            bool isExist = (LstCodeNumber.Count() > 0);
            int iTotalAmount = 0;

            foreach (string sCodeNumber in LstCodeNumber)
            {
                isPossible = isPossible && Generator.isPossibleCode(sCodeNumber);
                isExist = isExist && PacificCodeBUS.isExist(sCodeNumber);

                if (isPossible && isExist)
                {
                    iTotalAmount += PacificCodeBUS.getActualAmount(sCodeNumber);
                }
                else
                {
                    break;
                }
            }

            PaymentModel paymentModel = new PaymentModel();
            
            // Thanh Toán & Trả ra kết quả
            // *** Giả sử đã thanh toán hết (qua web), đã lưu xuống sau đó gửi lại 
            // thông báo cho admin của trang web nhưng admin không nhận được
            // => khách hàng bị mất tiền nhưng không nhận được hàng.. SAU NÀY SỬA
            // getMoneyForPayment => trả ra giá trị đã lấy để thanh toán

            if (isExist && isPossible && (iTotalAmount >= Amount))
            {
                for(int i = 0; i < LstCodeNumber.Count() && Amount > 0; i++)
                {                       
                    Amount = Amount - PacificCodeBUS.getMoneyForPayMent(LstCodeNumber[i], Amount);
                }
                
                paymentModel.Success = true;
                paymentModel.Message = MessageManager.GetValue("MAKE_PAYMENT_SUCCESS");
            }
            else
            {
                paymentModel.Success = false;
                paymentModel.Message = MessageManager.GetValue("MAKE_PAYMENT_UNSUCCESS");
            }

            return paymentModel;
        }
    }
}