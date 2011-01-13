using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPDataAccess;
using MoneyPacificBlackBox.DTO;

namespace MoneyPacificService.BUS
{
    public class PartPacificCodeBUS
    {
        /// <summary>
        /// Tạo 1 PacificCode có giá trị amountBuy
        /// Lấy 12/16 lưu lại trong PartPacificCode
        /// </summary>
        internal static PartPacificCode GetNewPacificCode(Guid storeGuid, Guid customerGuid, int amountBuy)
        {
            BlackBoxServiceClient clientService = new BlackBoxServiceClient();
            PartPacificCode newPartPacificCode = new PartPacificCode();
  
            string codeNumber = clientService.NewPacificCode(amountBuy);
            
            newPartPacificCode.PartCodeNumber = GetPartCodeNumber(codeNumber);
            newPartPacificCode.StoreUserId = storeGuid;
            newPartPacificCode.CustomerId = customerGuid;

            ///clientService.Close(); // Lỗi khi đang gọi bị đóng seviceClient
            return newPartPacificCode;            
        }

        private static string GetPartCodeNumber(string codeNumber)
        {
            return codeNumber.Substring(0, 12);
        }

        internal static double GetActualAmount(string partCodeNumber)
        {
            BlackBoxServiceClient clientService = new BlackBoxServiceClient();
            double result = (double)clientService.GetValue(partCodeNumber);
            ///clientService.Close(); // Lỗi khi đang gọi bị đóng seviceClient
            return result;
        }

        internal static DateTime GetExpireDate(string partCodeNumber)
        {
            BlackBoxServiceClient clientService = new BlackBoxServiceClient();
            DateTime result = clientService.GetExpireDate(partCodeNumber);
            ///clientService.Close(); // Lỗi khi đang gọi bị đóng seviceClient
            return result;
        }

        internal static bool IsExist(string codeNumber)
        {
            BlackBoxServiceClient clientService = new BlackBoxServiceClient();
            bool isExist = clientService.IsExist(codeNumber);
            ///clientService.Close(); // Lỗi khi đang gọi bị đóng seviceClient
            return isExist;
        }

        internal static bool IsPossibleCode(string codeNumber)
        {
            BlackBoxServiceClient clientService = new BlackBoxServiceClient();
            bool isPossible = clientService.IsPossible(codeNumber);
            ///clientService.Close(); // Lỗi khi đang gọi bị đóng seviceClient
            return isPossible;
        }

        internal static PacificCodeViewModel GetPacificCodeViewModel(string partCodeNumber)
        {
            BlackBoxServiceClient clientService = new BlackBoxServiceClient();
            PacificCodeViewModel model = clientService.GetPacificCodeViewModel(partCodeNumber);
            ///clientService.Close(); // Lỗi khi đang gọi bị đóng seviceClient
            return model;
        }
    }
}