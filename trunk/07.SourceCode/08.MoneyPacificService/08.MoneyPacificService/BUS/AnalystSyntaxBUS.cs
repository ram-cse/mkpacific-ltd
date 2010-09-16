using System;             
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _08.MoneyPacificService.DTO;


namespace _08.MoneyPacificService.BUS
{
    public class AnalystSyntaxBUS
    {
        public static char separateChar = '*';

        // public static 

        internal static Store getSender(string smsContent)
        {
            try
            {
                string[] arrArgs = smsContent.Split(separateChar);
                Store newStore = new Store();
                newStore.Phone = arrArgs[0];
                newStore.PassStore = arrArgs[1];

                return newStore;
            }
            catch
            {
                return null;
            }
        }

        internal static int getAmount(string smsContent)
        {
            try
            {
                string[] arrArgs = smsContent.Split(separateChar);
                return int.Parse(arrArgs[4]);
            }
            catch
            {
                return 0;
            }
        }

        internal static int getAmountConfirm(string smsContent)
        {
            try
            {
                string[] arrArgs = smsContent.Split(separateChar);
                return int.Parse(arrArgs[3]);
            }
            catch
            {
                return 0;
            }
        }

        internal static Customer getCustomer(string smsContent)
        {
            Customer newCustomer = new Customer();

            try
            {
                string[] arrArgs = smsContent.Split(separateChar);                
                newCustomer.Phone = arrArgs[3];                
            }
            catch
            {
                newCustomer.Phone = "ERROR!.";
            }

            return newCustomer;
        }

        internal static string getCommand(string smsContent)
        {
            try
            {
                string[] arrArgs = smsContent.Split(separateChar);
                return arrArgs[0];
            }
            catch
            {
                return "ERROR!.";
            }
        }
    }
}