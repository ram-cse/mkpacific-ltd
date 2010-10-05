using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificSrv.DTO;
using MoneyPacificSrv.BUS;
using MoneyPacificSrv.Util;

namespace MoneyPacificSrv.Cmd
{
    public class BuyPacificCodeCmd : IMPCommand
    {
        public string Execute(string[] args)
        {
            // Cú pháp SMS:
            // <StorePhone>*<PassStore>*<Amount>*<CustomerPhone>*<AmountConfirm>

            string smsRespones = "";
            string sErrorMessage = "";

            // Get information :-----------------------
            
            Store senderStore = new Store();
            senderStore.Phone = args[0];
            senderStore.PassStore = args[1];

            int amountBuy = int.Parse(args[2]);
            int amountBuyConfirm = int.Parse(args[4]);

            Customer buyerCustomer = new Customer();
            buyerCustomer.Phone = args[3];

            // Check Information:-----------------------            

            // 01. check STORE
            bool bSenderExists = StoreBUS.checkExist(senderStore);
            if (!bSenderExists)
            {   
                smsRespones = senderStore.Phone + "*" + MessageManager.getValue("NOT_EXIST_STORE");
                return smsRespones;
            }

            // 02. check STORE (password & status)
            bool bValidPassword = false;
            bValidPassword = StoreBUS.checkPassword(senderStore);

            if (!bValidPassword)
            {   
                sErrorMessage += MessageManager.getValue("WRONG_PASSWORD");
            }
            else
            {
                senderStore = StoreBUS.getStore(senderStore.Phone, senderStore.PassStore);
            }

            // *** KIEM TRA KH BLACK LIST sau khi Kiem tra STORE
            if (CustomerBUS.isInBlackList(buyerCustomer.Phone))
                return senderStore.Phone.Trim() + "*" + MessageManager.getValue("CUSTOMER_IN_BLACK_LIST");

            // 03. check PACIFIC CODE Categories
            bool bValidAmount = false;
            bValidAmount = CategoriesBUS.isValidAmount(amountBuy);

            if (!bValidAmount)
            {
                sErrorMessage += MessageManager.getValue("INVALID_AMOUNT_MESSAGE", amountBuy.ToString());                
            }

            // 04. check CONFIRM AMOUNT
            bool bValidConfirm = (amountBuy == amountBuyConfirm);

            if (!bValidConfirm)
            {
                sErrorMessage += MessageManager.getValue("INVALID_AMOUNT_CONFIRM");                
            }

            // 05. check PHONE (valid and status)
            bool bValidPhone = Validator.isPhoneNumber(buyerCustomer.Phone);

            if (!bValidPhone)
            {
                sErrorMessage = MessageManager.getValue("INVALID_PHONE");                
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
                PacificCode newPacificCode = PacificCodeBUS.getNewPacificCode(senderStore.ID, buyerCustomer.ID, amountBuy);

                smsRespones = buyerCustomer.Phone.Trim();
                
                
                smsRespones += "*" + MessageManager.getValue("GENERATE_SUCCESSFUL", 
                    Utility.insertSeparateChar(newPacificCode.CodeNumber.Trim(),' ',4),
                    newPacificCode.ActualAmount.ToString(),
                    ((DateTime)newPacificCode.ExpireDate).ToShortDateString());
                
                // Mua thanh cong thi CustomerSTATUS = "x01"
                CustomerBUS.setStatus(buyerCustomer.Phone, "x01");

                // Log Transaction info
                TransactionBUS.addNew(newPacificCode);
            }
            else
            {
                smsRespones = senderStore.Phone.Trim(' ');
                smsRespones += "*" + sErrorMessage;
                
                // Log Transaction info
                // ...
            }

            return smsRespones;
        }

        

                
        
    }
}