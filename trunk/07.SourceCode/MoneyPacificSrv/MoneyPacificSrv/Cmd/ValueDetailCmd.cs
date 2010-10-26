using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.Util;
using MoneyPacificSrv.DTO;
using MoneyPacificSrv.BUS;

namespace MoneyPacificSrv.Cmd
{
    public class ValueDetailCmd : IMPCommand
    {
        #region IMPCommand Members

        
        public string Execute(string[] args)
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

            string senderPhone = args[0];
            if (!Validator.isPhoneNumber(senderPhone)) return "Sender is Invalid!..";
            
            Customer existCustomer = CustomerBUS.getCustomerOrCreateNotYetBuy(senderPhone);
            
            string sCodeNumber = args[1];
            sCodeNumber = Utility.removeSpaceChar(sCodeNumber);
            sCodeNumber = Utility.removeChar(sCodeNumber,'-');

            string sMessage = "";

            if (PacificCodeBUS.isExist(sCodeNumber))
            {
                PacificCode existPacificCode = PacificCodeBUS.getPacificCode(sCodeNumber);
                
                // Amoung > 0

                string customerStatus = CustomerBUS.makeSuspicion(existCustomer.Id);
                // Amount > 0 : Charge Fee 

                sMessage = existCustomer.Phone.Trim() + "*"
                    + MessageManager.getValue("CHECK_VALUE_DETAIL_SUCCESSFUL",
                        Utility.insertSeparateChar(existPacificCode.CodeNumber, ' '),
                        existPacificCode.ActualAmount.ToString(),
                        ((DateTime)existPacificCode.ExpireDate).ToShortDateString());                
            }
            else // Pacific is NO EXIST
            {
                if (PacificCodeBUS.isPossibleCode(sCodeNumber))
                {
                    // Add to Black List
                    CustomerBUS.moveToBlackList(existCustomer.Phone);
                    sMessage = "0*" + MessageManager.getValue("BE_BLACK_LIST");
                }
                else
                {
                    sMessage = CustomerBUS.makeSuspicion(existCustomer.Id);
                }
            }

            if (sMessage != "")
                return sMessage;
            else
                return "Error!..";
        }

        #endregion
    }
}