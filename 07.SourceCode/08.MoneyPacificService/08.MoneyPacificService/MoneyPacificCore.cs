using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _08.MoneyPacificService;
using _08.MoneyPacificService.DTO;
using _08.MoneyPacificService.DAO;
using _08.MoneyPacificService.BUS;
using _08.MoneyPacificService.Util;

namespace _08.MoneyPacificService
{
    public class MoneyPacificCore
    {
        internal static DBMoneyPacificDataContext mpdb = new DBMoneyPacificDataContext();

        internal static string getRequest(string smsContent)
        {
            // *** GIẢI MÃ - DECODE *** (not yet)
            // smsContent = Coder.DeCode(smsContent);

            /* // BEGIN TEST
            Customer existCustomer = mpdb.Customers.Where(c => c.ID == 1).Single();

            if (existCustomer.NumberTransaction == null)
            {
                existCustomer.NumberTransaction = 0;
            }
            else
            {
                existCustomer.NumberTransaction++;
            }

            mpdb.SubmitChanges();

            return "test finished";
            // END TEST*/

            string smsResponse = "";

            string[] arrArg = smsContent.Split('*').ToArray();

            if (arrArg.Length == 1)
            {
                int newId = CustomerBUS.AddNew(smsContent);
                return "this is an unit test: " + newId;
            }
            
            // command: chưa sử dụng
            string command = AnalystSyntaxBUS.getCommand(smsContent);

            // Cần sửa lại cách nhận lệnh và tham số giống DOS Command
            
            Store senderStore = AnalystSyntaxBUS.getSender(smsContent);
            int amountBuy = AnalystSyntaxBUS.getAmount(smsContent);
            int amountBuyConfirm = AnalystSyntaxBUS.getAmountConfirm(smsContent);
            Customer buyerCustomer = AnalystSyntaxBUS.getCustomer(smsContent);

            smsResponse = buyNewPacificCode(senderStore,amountBuy,buyerCustomer,amountBuyConfirm);
            //smsResponse = smsResponse + "---" + Coder.EnCode(smsResponse); // Kiểm tra ma hoa
            //smsResponse = Coder.EnCode(smsResponse); // Mã hóa (đơn giản, nên dùng DynamicKey)
            return smsResponse;
        }

        //internal static string 

        private static string buyNewPacificCode(Store senderStore, int amountBuy, Customer buyerCustomer, int amountBuyConfirm)
        {
            
            string smsResponse = "";
            string sErrorMessage = "";


            // KIỂM TRA
            // 01. Kiểm tra Store tồn tại & STATUS của Store.
            // (Tách kiểm tra exist & pass ra thành 2 phần để báo lỗi rõ hơn)

            bool bSenderExist = StoreBUS.checkExist(senderStore);

            if (!bSenderExist)
            {
                smsResponse = MessageManager.GenNotExistStoreMessage(senderStore.Phone);
                return smsResponse;
            }

            // 02. Kiểm tra PassStore
            
            bool bCheckValidPassword = false;

            bCheckValidPassword = StoreDAO.checkPassword(senderStore);

            if (!bCheckValidPassword)
            {
                sErrorMessage += MessageManager.GenErrorPasswordStoreMessage();
            }
            else // Neu dung password thi moi cho lay thong tin
            {
                // Sau khi kiem tra xong tồn tại thì nhận thông tin Store, Store ID để tạo PacificCode
                senderStore = StoreBUS.getStore(senderStore.Phone, senderStore.PassStore);
            }        

            
            
            
            // 03. Kiểm tra AMOUNT hợp lệ (load các loại thẻ đang bán)
            
            bool bValidAmount = MoneyCardBUS.checkValid(amountBuy);
            
            if (!bValidAmount)
            {
                sErrorMessage += MessageManager.GenInValidAmountMessage(amountBuy);
            }

            // 04. Kiểm tra AMOUNT_CONFIRM             

            bool bValidConfirm = (amountBuy == amountBuyConfirm);

            if (!bValidConfirm)
            {
                sErrorMessage += MessageManager.GenInValidAmountConfirmMessage();
            }

            // 05. Kiểm tra CUSTOMER_PHONE hợp lệ

            bool bValidPhone = checkPhoneNumber(buyerCustomer.Phone);
            
            if (!bValidPhone)
            {
                sErrorMessage += MessageManager.GenInValidPhoneMessage();
            }

            // 06. Kiểm tra CUSTOMER_PHONE (tồn tại và STATUS)

            bool bCheckValidCustomer = false;

            buyerCustomer = CustomerBUS.getCustomer(buyerCustomer.Phone);
            bCheckValidCustomer = CustomerBUS.checkCustomer(buyerCustomer);
                       
            
            // Gửi 2 tin nhắn cho CUSTOMER & STORE (chưa làm cái này, phải xác định lại cấu trúc tin nhắn mới có thể làm được)

            bool bRegisterSuccess = (
                bCheckValidPassword
                && bValidAmount
                && bValidConfirm
                && bValidPhone
                && bCheckValidCustomer
                );

            if (bRegisterSuccess)
            {
                // Tạo PACIFIC_CODE mới với buyerCustomer (chắc chắn tạo dc)
                PacificCode newPacificCode = PacificCodeBUS.getNewPacificCode(senderStore.ID, buyerCustomer.ID, amountBuy); 
                
                smsResponse = buyerCustomer.Phone.Trim();
                smsResponse += "*" + MessageManager.GenSucessCreatePacificCodeMessage(newPacificCode);

                // Log Transaction
                TransactionBUS.AddNew(newPacificCode);
            }
            else
            {
                
                smsResponse = senderStore.Phone;
                smsResponse += "*" + sErrorMessage;

                // Log Transaction
            }

            return smsResponse;
        }

        private static bool checkPhoneNumber(string sPhoneNumber)
        {
            // throw new NotImplementedException();
            // Chiều dài số điện thoại cần được định nghĩa lại
            // Quy định lại số dt như thế nào thì được gọi là số điện thoại hợp lệ..

            bool bResult = true;

            bResult = bResult && (sPhoneNumber.Length < 13) && (sPhoneNumber.Length >= 10);
            
            for (int i = 0; i < sPhoneNumber.Length; i++)
            {
                bResult = bResult && Char.IsDigit(sPhoneNumber[i]);                
            }

            return bResult;
        }
    }
}