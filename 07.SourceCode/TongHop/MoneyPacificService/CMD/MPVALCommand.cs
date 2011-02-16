using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyPacificService.Util;
using MoneyPacificService.BUS;
using MPDataAccess;
using MoneyPacificBlackBox.DTO;

namespace MoneyPacificService.CMD
{
    internal class MPVALCommand : AMPCommand
    {
        /* PSEUDO CODE
        * 
        * Get information
        * 
        * SMS customer no exist -> create new customer
        * getCustomter
        *      <Function makeSuspicion()>
        *      {
        *          a1. (Customer.status == [.]) -> Customer.Status = 031
        *          a2. (Customer.status == x31) -> Customer.Status = x32
        *          a3. (Customer.status == x32) -> Customer.Status = x33
        *          a4. (Customer.status == x33) -> Customer.Status = x93
        *      }
        * 1. Code No Exist
        *      a. No Possible Code
        *          -> makeSuspicion()    
        *      b. Possible Code
        *          Customer.status = x98 (BLACK LIST)
        * 2. Code Exist:
        *      a. Value = 0:
        *          -> makeSuspicion()
        *      b. 0 < Value < Fee (charge for this command)
        *          reply 
        *          Charge (may be makeSuspicion)
        *      c. Value > Fee:
        *          Return INFO
        *          Charge
        * */
        internal override string Execute()
        {
            string senderPhone = args[0];
            if (!Validator.isPhoneNumber(senderPhone)) return "Sender is Invalid!..";

            Customer existCustomer = CustomerBUS.GetCustomerOrCreateNotYetBuy(senderPhone);

            string codeNumber = args[1];
            codeNumber = Utility.removeSpaceChar(codeNumber);
            codeNumber = Utility.removeChar(codeNumber, '-');

            string sMessage = "";

            if (PartPacificCodeBUS.IsExist(codeNumber))
            {
                //PartPacificCode existPacificCode = PacificCodeBUS.getPacificCode(sCodeNumber);
                //int actualAmount = PartPacificCodeBUS.GetActualAmount(sCodeNumber);
                //int E
                PacificCodeViewModel model = PartPacificCodeBUS.GetPacificCodeViewModel(codeNumber);

                // Amoung > 0

                // ? ko nhớ đã dùng để làm gì :-s => dùng để lưu trang thái mac định của customer
                string customerStatus = CustomerBUS.makeSuspicion(existCustomer.UserId);
                // Amount > 0 : Charge Fee 

                sMessage = existCustomer.PhoneNumber.Trim() + "*"
                    + MessageManager.GetValue("CHECK_VALUE_DETAIL_SUCCESSFUL",
                        Utility.insertSeparateChar(model.CodeNumber, ' '),
                        model.ActualAmount.ToString(),
                        ((DateTime)model.ExpireDate).ToShortDateString());
            }
            else // Pacific is NO EXIST
            {
                if (PartPacificCodeBUS.IsPossibleCode(codeNumber))
                {
                    // Add to Black List
                    CustomerBUS.MoveToBlackList(existCustomer.PhoneNumber);
                    sMessage = "0*" + MessageManager.GetValue("BE_BLACK_LIST");
                }
                else
                {
                    sMessage = CustomerBUS.makeSuspicion(existCustomer.UserId);
                }
            }

            if (sMessage != "")
                return sMessage;
            else
                return "Error!..";
        }
    }
}