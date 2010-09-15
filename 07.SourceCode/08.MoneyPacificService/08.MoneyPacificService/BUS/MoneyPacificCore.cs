using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _08.MoneyPacificService;
using _08.MoneyPacificService.DTO;
using _08.MoneyPacificService.DAO;


namespace _08.MoneyPacificService.BUS
{
    public class MoneyPacificCore
    {
        public DBMoneyPacificDataContext db = new DBMoneyPacificDataContext();

        public string GetRequest(string smsContent)
        {

            string smsResponse = "";

            // Nhận thông tin người gửi

            string command = AnalystSyntaxBUS.getCommand(smsContent);
            Store senderStore = AnalystSyntaxBUS.getSender(smsContent);
            int amountBuy = AnalystSyntaxBUS.getAmount(smsContent);
            int amountBuyConfirm = AnalystSyntaxBUS.getAmountConfirm(smsContent);
            Customer newCustomer = AnalystSyntaxBUS.getCustomer(smsContent);

            bool bSenderExist = StoreDAO.checkExist(senderStore);
            bool bCheckValidPassword = false;

            if (bSenderExist)
            {
                bCheckValidPassword = StoreDAO.checkPassword(senderStore);
            }

            bool bValidAmount = MoneyCardBUS.checkValid(amountBuy);
            bool bValidConfirm = (amountBuy == amountBuyConfirm);

            bool bValidPhone = checkPhoneNumber(newCustomer.Phone);

            bool bGetNew = false;
            
            PacificCode newPacificCode;

            do
            {                
                newPacificCode = GeneratorBUS.CreateNewCode();
                bGetNew = !GeneratorBUS.checkExist();
            } while (bGetNew == false);

            bool bRegisterSuccess = (true);

            if (bRegisterSuccess)
            {
                smsResponse = newCustomer.Phone;
                
                // Lưu:
                // Thông tin khách hàng (nếu là khách hàng mới thì thêm mới)
                // Thông tin PacificCode với người sử dụng là newCustomer

                // Cần viết một lóp có phương thức hoạt động như sau: truyền
                // giá trị PCODE vào sẽ tự động sinh ra lời nhắn chuẩn
                // Lời nhắn này được đọc từ tập tin XML

                smsResponse += "*This is new PACIFIC CODE:" + newPacificCode.ToString()
                    + ". It have value: " + amountBuy;

            }

            

            return smsResponse;
        }

        private bool checkPhoneNumber(string p)
        {
            throw new NotImplementedException();
        }
    }
}