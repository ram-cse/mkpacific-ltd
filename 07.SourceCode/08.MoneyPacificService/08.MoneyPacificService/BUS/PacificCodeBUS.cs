using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;

using _08.MoneyPacificService.DAO;
using _08.MoneyPacificService.DTO;
using _08.MoneyPacificService.XAO;


namespace _08.MoneyPacificService.BUS
{
    public class PacificCodeBUS
    {

        private static int[] arrCode = new int[16];

        internal static int AddNew(PacificCode newPCode)
        {
            // Lưu thông tin liên quan lên Store, Customer   
            // Sẽ sửa cho tự động lưu..(clr-trg)..

            StoreDAO.UpdateAfterInsertNewPCode(newPCode);
            CustomerDAO.UpdateAfterInsertNewPCode(newPCode);

            return PacificCodeDAO.AddNew(newPCode);
        }

        internal static PacificCode GenerateNewCode()
        {
            Random randomNumer = new Random();
            PacificCode newPCode = new PacificCode();

            newPCode.PacificCode1 = "";
            
            for (int i = 0; i<=15; i++)
            {
                arrCode[i] = randomNumer.Next(10);
                newPCode.PacificCode1 += arrCode[i].ToString();
            }

            return newPCode;
        }

        internal static PacificCode GenerateNewCode(string xmlFile)
        {
            return PacificCodeXAO.GenerateNewCode(xmlFile);
        }


        internal static bool checkExist(string sPacificCode)
        {
            return PacificCodeDAO.checkExist(sPacificCode);
        }

        internal static PacificCode getNewPacificCode(int storeId, int customerId, int amount)
        {
            PacificCode newPacificCode = new PacificCode();

            //string xmlRuleFile = Directory.GetCurrentDirectory() + "\\App_Data\\PacificCodeR.xml";
            string xmlRuleFile = AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\PacificCodeR.xml";

            bool bGetNewPacificCode = false;
            do
            {
                // Tạo Random
                // newPacificCode = PacificCodeBUS.GenerateNewCode(); 
                
                // Tạo theo Rule
                newPacificCode = PacificCodeBUS.GenerateNewCode(xmlRuleFile); 

                // Nếu đã tồn tại(tỉ lệ xảy ra là 1/10^11)
                bGetNewPacificCode = !PacificCodeBUS.checkExist(newPacificCode.PacificCode1);

            } while (bGetNewPacificCode == false);

            // 
            newPacificCode.StoreID = storeId;
            newPacificCode.CustomerID = customerId;
            newPacificCode.InitialAmount = amount;
            newPacificCode.ActualAmount = amount;

            newPacificCode.Date = DateTime.Now;

            // Xác định ngày hết hạn, mặc định là 1 năm từ ngày mua
            int iYear = DateTime.Now.Year + 1;
            int iMonth = DateTime.Now.Month;
            int iDay = DateTime.Now.Day;

            newPacificCode.ExpireDate = new DateTime(iYear,iMonth,iDay);

            PacificCodeBUS.AddNew(newPacificCode);

            return newPacificCode;            
        }
    }
}