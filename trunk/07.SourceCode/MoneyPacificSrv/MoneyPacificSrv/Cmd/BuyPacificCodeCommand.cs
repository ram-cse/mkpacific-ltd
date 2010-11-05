using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificSrv.DTO;
using MoneyPacificSrv.BUS;
using MoneyPacificSrv.Util;

namespace MoneyPacificSrv.Cmd
{
    public class BuyPacificCodeCommand : IMPCommand
    {
        
        public string Execute(string[] args)
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
            buyerCustomer.Phone = args[3];

            // Check Information:-----------------------            

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
            bool bValidPassword = false;
            bValidPassword = StoreUserBUS.checkPassword(senderStore);

            if (!bValidPassword)
            {   
                sErrorMessage += MessageManager.GetValue("WRONG_PASSWORD");
            }
            else
            {
                senderStore = StoreUserBUS.getStoreUser(senderStore.Phone, senderStore.PINStore);
            }

            // *** KIEM TRA KH BLACK LIST sau khi Kiem tra STORE
            if (CustomerBUS.isInBlackList(buyerCustomer.Phone))
                return senderStore.Phone.Trim() + "*" + MessageManager.GetValue("CUSTOMER_IN_BLACK_LIST");

            // 03. check PACIFIC CODE Categories
            bool bValidAmount = false;
            bValidAmount = CategoriesBUS.isValidAmount(amountBuy);

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
            bool bValidPhone = Validator.isPhoneNumber(buyerCustomer.Phone);

            if (!bValidPhone)
            {
                sErrorMessage = MessageManager.GetValue("INVALID_PHONE");                
            }

            // 06. check CUSTOMER (exist and status)
            buyerCustomer = CustomerBUS.getCustomerOrCreateNotYetBuy(buyerCustomer.Phone);
                        
            // Get result: --------------------------
            
            bool bBuyPCodeSuccess = (
                bValidPassword
                && bValidAmount
                && bValidConfirm
                && bValidPhone            
                );

            if (bBuyPCodeSuccess)
            {
                if (StoreUserBUS.IsEnable(senderStore.Id))
                {
                    PacificCode newPacificCode = PacificCodeBUS.getNewPacificCode(senderStore.Id, buyerCustomer.Id, amountBuy);

                    sReceiverPhone = buyerCustomer.Phone.Trim();
                    sContentSMS = MessageManager.GetValue("GENERATE_SUCCESSFUL",
                        Utility.insertSeparateChar(newPacificCode.CodeNumber.Trim(), ' ', 4),
                        newPacificCode.ActualAmount.ToString(),
                        ((DateTime)newPacificCode.ExpireDate).ToShortDateString());                   
                    
                    smsRespones = sReceiverPhone + "*" + sContentSMS;

                    // Mua thanh cong thi CustomerSTATUS = "x01"
                    CustomerBUS.setStatus(buyerCustomer.Phone, "x01");

                    // Log Transaction info
                    TransactionBUS.addNew(newPacificCode);
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
                sReceiverPhone = senderStore.Phone.Trim(' ');
                sContentSMS = sErrorMessage;                
                smsRespones = sReceiverPhone + "*" + sContentSMS;
                
                // Log Transaction info
                // ...
            }

            return smsRespones;
        }

        

                
        
    }
}