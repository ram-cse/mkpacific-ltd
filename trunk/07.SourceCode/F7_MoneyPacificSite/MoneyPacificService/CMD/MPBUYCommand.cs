using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPDataAccess;
using MoneyPacificService.BUS;
using MoneyPacificService.Util;
using MoneyPacificBlackBox.DTO;

namespace MoneyPacificService.CMD
{
    internal class MPBUYCommand : AMPCommand
    {
        internal override string Execute()
        {
     // Cú pháp SMS:
            // <StorePhone>*<PINStore>*<Amount>*<CustomerPhone>*<AmountConfirm>

            string smsRespones = "";
            string sErrorMessage = "";
            string sReceiverPhone = "";
            string sContentSMS = "";

            // Get information :-----------------------

            StoreUser senderStore = new StoreUser();
            senderStore.Phone = args[0];
            senderStore.PINStore = args[1];

            int amountBuy = int.Parse(args[2]);
            int amountBuyConfirm = int.Parse(args[4]);

            Customer buyerCustomer = new Customer();
            buyerCustomer.PhoneNumber = args[3];

            // 01. check STORE
            bool bSenderExists = StoreUserBUS.IsExist(senderStore);
            if (!bSenderExists)
            {
                sReceiverPhone = senderStore.Phone.Trim();
                sContentSMS = MessageManager.GetValue("NOT_EXIST_STORE");
                smsRespones = sReceiverPhone + "*" + sContentSMS;
                return smsRespones;
            }

            
            // 02. check StoreUser (password & status)
            bool bValidPINStore = false;
            bValidPINStore = StoreUserBUS.checkPINStore(senderStore);

            if (!bValidPINStore)
            {
                sErrorMessage += MessageManager.GetValue("WRONG_PINSTORE");
            }
            else
            {
                senderStore = StoreUserBUS.GetObject(senderStore.Phone);
            }

            // *** KIEM TRA KH BLACK LIST sau khi Kiem tra STORE
            if (CustomerBUS.isInBlackList(buyerCustomer.PhoneNumber))
                return senderStore.Phone.Trim() + "*" + MessageManager.GetValue("CUSTOMER_IN_BLACK_LIST");

            // 03. check PACIFIC CODE Categories
            bool bValidAmount = false;
            bValidAmount = CategoryBUS.IsValidAmount(amountBuy);

            if (!bValidAmount)
            {
                sErrorMessage += MessageManager.GetValue("INVALID_AMOUNT_MESSAGE", amountBuy.ToString());
            }

            // 04. check CONFIRM AMOUNT
            bool bValidConfirm = (amountBuy == amountBuyConfirm);

            if (!bValidConfirm)
            {
                sErrorMessage += MessageManager.GetValue("INVALID_AMOUNT_CONFIRM");
            }

            // 05. check PHONE (valid and status)
            bool bValidPhone = Validator.isPhoneNumber(buyerCustomer.PhoneNumber);

            if (!bValidPhone)
            {
                sErrorMessage = MessageManager.GetValue("INVALID_PHONE");
            }

            // 06. check CUSTOMER (exist and status)
            buyerCustomer = CustomerBUS.GetCustomerOrCreateNotYetBuy(buyerCustomer.PhoneNumber);

            // Get result: --------------------------

            bool bBuyPCodeSuccess = (
                bValidPINStore
                && bValidAmount
                && bValidConfirm
                && bValidPhone
                );

            // đang lam den day
            
            if (bBuyPCodeSuccess)
            {
                if (StoreUserBUS.IsEnable(senderStore.UserId))
                {
                    // Thuc hien mua va luu xuong database
                    PartPacificCode newPartPacificCode = PartPacificCodeBUS.GetNewPacificCode
                        (senderStore.UserId, buyerCustomer.UserId, amountBuy);
                    
                    
                    // Lay thong tin xuat ra cho khach hang
                    PacificCodeViewModel pacificCode = PartPacificCodeBUS.GetPacificCodeViewModel(
                        newPartPacificCode.PartCodeNumber);

                    sReceiverPhone = buyerCustomer.PhoneNumber.Trim();
                    sContentSMS = MessageManager.GetValue("GENERATE_SUCCESSFUL",
                        Utility.insertSeparateChar(pacificCode.CodeNumber, ' ', 4),
                        pacificCode.ActualAmount.ToString(),
                        pacificCode.ExpireDate.ToShortDateString());

                    smsRespones = sReceiverPhone + "*" + sContentSMS;

                    // Mua thanh cong thi CustomerSTATUS = "x01"
                    //CustomerBUS.setStatus(buyerCustomer.Phone, "x01");

                    // Log Transaction info
                    //TransactionBUS.addNew(newPartPacificCode);
                }
                else // DISABLE
                {
                    sReceiverPhone = senderStore.Phone.Trim();
                    sContentSMS = MessageManager.GetValue("STORE_IS_DISABLE");
                    smsRespones = sReceiverPhone + "*" + sContentSMS;
                }
            }
            else //ERROR:
            {
                // Thương lỗi do bValidAmount = false => kiem tra du lieu
                sReceiverPhone = senderStore.Phone.Trim(' ');
                sContentSMS = sErrorMessage;
                smsRespones = sReceiverPhone + "*" + sContentSMS;

                // Log Transaction info
                // ...
            }

            //BlackBoxServiceClient serviceClient = new BlackBoxServiceClient();
            //string newCode = serviceClient.NewPacificCode(500000);

            //smsRespones = newCode;
            
            return smsRespones;
            
            // Check Information:-----------------------
            // return base.Execute();
        }
    }
}