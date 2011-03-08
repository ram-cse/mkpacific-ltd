using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MPDataAccess;
using MoneyPacificBlackBox.DTO;

namespace MoneyPacificSite.BUS
{
    public class PartPacificCodeBUS
    {
        internal static List<PartPacificCode> GetList()
        {
            return PartPacificCodeDAO.GetList();
        }

        internal static PacificCodeViewModel GetPacificCodeViewModel(string partCodeNumber)
        {
            BlackBoxServiceClient clientService = new BlackBoxServiceClient();
            PacificCodeViewModel model = clientService.GetPacificCodeViewModel(partCodeNumber);
            ///clientService.Close(); // Lỗi khi đang gọi bị đóng seviceClient
            return model;
        }

        internal static PartPacificCode GetObject(string partCodeNumber)
        {
            return PartPacificCodeDAO.GetObject(partCodeNumber);
        }

        internal static bool IsExist(string partCodeNumber)
        {
            BlackBoxServiceClient clientService = new BlackBoxServiceClient();

            // Kiểm tra tồn tại trong BlackBox & trong Security
            bool result = clientService.IsExist(partCodeNumber);
            result = result & PartPacificCodeDAO.IsExist(partCodeNumber);

            return result;
        }

        internal static PacificCodeViewModel SendMoney(string codeNumber, string phoneNumber, double amount)
        {
            BlackBoxServiceClient clientService = new BlackBoxServiceClient();
            string newCodeNumber = clientService.MakePayment(codeNumber, (int)amount);

            /// Lưu thông tin liên quan đến khách hàng
            PartPacificCode newPartPacficiCode = new PartPacificCode();
            Customer existCustomer = CustomerBUS.GetCustomerOrCreateNotYetBuy(phoneNumber);

            newPartPacficiCode.CustomerId = existCustomer.UserId;
            newPartPacficiCode.StoreUserId = null;

            // Lấy ID tự động?
            PartPacificCodeDAO.AddNew(newPartPacficiCode);

            /// Lấy payment model, trả ra kết quả
            PacificCodeViewModel model = clientService.GetPacificCodeViewModel(newCodeNumber);
            return model;
        }

        internal static PacificCodeViewModel GetLastPacificCode(Guid customerUserId)
        {
            string[] arrCodeNumber = PartPacificCodeDAO.GetArray(customerUserId);

            if (arrCodeNumber.Count() > 0)
            {
                BlackBoxServiceClient clientService = new BlackBoxServiceClient();
                PacificCodeViewModel[] arrPCVM = clientService.GetArrayPacificCodeViewModel(arrCodeNumber);
                PacificCodeViewModel lastPCVM = arrPCVM[0];

                foreach (PacificCodeViewModel item in arrPCVM)
                {
                    if (item.CreateDate > lastPCVM.CreateDate)
                    {
                        lastPCVM = item;
                    }
                }
                return lastPCVM;
            }
            return null;
        }

        // codeNumber phải đủ 16 số..
        internal static string ChangeCode(string oldCodeNumber)
        {
            string newCodeNumber;
            BlackBoxServiceClient clientService = new BlackBoxServiceClient();

            newCodeNumber = clientService.ChangeCode(oldCodeNumber);

            if (newCodeNumber != null)
            {
                PartPacificCode existPPC = PartPacificCodeDAO.GetObject(oldCodeNumber);
                existPPC.PartCodeNumber = newCodeNumber.Substring(0, 12);

                PartPacificCodeDAO.Update(existPPC);

                return newCodeNumber;
            }
            return null;
        }
    }
}