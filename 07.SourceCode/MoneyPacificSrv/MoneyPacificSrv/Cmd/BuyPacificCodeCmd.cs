using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificSrv.DTO;
using MoneyPacificSrv.BUS;
using MoneyPacificSrv.Util;

namespace MoneyPacificSrv.Cmd
{
    public class BuyPacificCodeCmd : IMPComand
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
            
            // 01.
            bool bSenderExists = StoreBUS.checkExist(senderStore);
            if (!bSenderExists)
            {
                smsRespones = MessageManager.GenNotExistStoreMessage(senderStore.Phone);
                return smsRespones;
            }

            // 02.
            bool bValidPassword = false;
            bValidPassword = StoreBUS.checkPassword(senderStore);

            if (!bValidPassword)
            {
                sErrorMessage += MessageManager.GenErrorPasswordMessage();
            }
            else
            {
                senderStore = StoreBUS.getStore(senderStore.Phone, senderStore.PassStore);
            }

            // 03.
            bool bValidAmount = false;
            bValidAmount = CategoriesBUS.isValidAmount(amountBuy);

            if (!bValidAmount)
            {
                sErrorMessage += MessageManager.GenInvalidAmountMessage(amountBuy);
            }

            // 04.
            bool bValidConfirm = (amountBuy == amountBuyConfirm);

            if (!bValidConfirm)
            {
                sErrorMessage += MessageManager.GenInvalidAmountConfirmMessage();
            }

            // 05.
            bool bValidPhone = Validator.isPhoneNumber(buyerCustomer.Phone);

            if (!bValidPhone)
            {
                sErrorMessage = MessageManager.GenInvalidPhoneMessage();
            }

            // 06.
            bool bValidCustomer = CustomerBUS.isValidCustomer(buyerCustomer.Phone);
                        
            // Get result: --------------------------
            
            bool bBuyPCodeSuccess = (
                bValidPassword
                && bValidAmount
                && bValidConfirm
                && bValidPhone
                && bValidCustomer
                );

            if (bBuyPCodeSuccess)
            {
                PacificCode newPacificCode = PacificCodeBUS.getNewPacificCode(senderStore.ID, buyerCustomer.ID, amountBuy);

                smsRespones = buyerCustomer.Phone.Trim();
                smsRespones += "*" + MessageManager.GenSuccessCreatePacificCodeMessage(newPacificCode);

                // Log Transaction info
                TransactionBUS.AddNew(newPacificCode);
            }
            else
            {
                smsRespones = senderStore.Phone;
                smsRespones += "*" + sErrorMessage;
                
                // Log Transaction info
                // ...
            }

            return smsRespones;
        }

        

                
        
    }
}