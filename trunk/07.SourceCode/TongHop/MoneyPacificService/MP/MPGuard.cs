using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificService.CMD;
using MoneyPacificService.DTO;
using MoneyPacificService.BUS;


namespace MoneyPacificService
{
    internal class MPGuard
    {
        private Invoker _invoker;
        private AMPCommand _command;

        /// <summary>
        /// Lưu transaction trong này?
        /// </summary>
        internal string Execute()
        {
            return this._command.Execute();
        }

        /// Sai thiết kế DP
        internal PaymentModel MakePayment(List<string> lstCodeNumber, int amount)
        {
            // throw new Exception("chua lam");
            // Can viet lai ..
            bool isPossible = (lstCodeNumber.Count() > 0); // Bắt buộc phải có CodeNumber
            bool isExist = (lstCodeNumber.Count() > 0);
            double iTotalAmount = 0;            

            foreach (string sCodeNumber in lstCodeNumber)
            {
                isPossible = isPossible && PartPacificCodeBUS.IsPossibleCode(sCodeNumber);
                isExist = isExist && PartPacificCodeBUS.IsExist(sCodeNumber);

                if (isPossible && isExist)
                {
                    iTotalAmount += PartPacificCodeBUS.GetActualAmount(sCodeNumber);
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

            if (isExist && isPossible && (iTotalAmount >= amount))
            {
                for (int i = 0; i < lstCodeNumber.Count() && amount > 0; i++)
                {
                    amount = amount - PartPacificCodeBUS.GetMoneyForPayMent(lstCodeNumber[i], amount);
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

        internal AMPCommand Command
        {
            set { this._command = value; }
        }        
    }

    internal class Invoker
    {
        private string _phoneNumber;

        internal String PhoneNumber
        {
            get { return _phoneNumber; }
        }

        internal Invoker(string phoneNumber)
        {
            // TODO: Complete member initialization
            this._phoneNumber = phoneNumber;
        }

        internal bool IsInBlackList()
        {
            // TODO: throw new Exception("chua lam!...");
            return false;
        }

        internal bool IsLockedCustomer()
        {
            // TODO:throw new Exception("chua lam!...");
            return false;
        }

        internal bool IsStoreUser()
        {
            // TODO: throw new Exception("chua lam!...");
            return true;
        }
        internal bool IsStoreManager()
        {
            // TODO: throw new Exception("chua lam!...");
            return true;
        }
        internal bool IsCustomer()
        {
            // TODO: throw new Exception("chua lam!...");
            return true;
        }
    }

    internal class Receiver
    {
        internal String PhoneNumber;
    }
}