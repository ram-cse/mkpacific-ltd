using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.DTO;
using System.Xml;
using MoneyPacificSrv.Util;


namespace MoneyPacificSrv.XAO
{
    public class PacificCodeXAO
    {
        internal static string xmlRuleFile = AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\PacificCodeR.xml"; 

        internal static PacificCode generateNewCode()
        {
            PacificCode newPCode = new PacificCode();

            List<PCArg> lstArg = new List<PCArg>();
            XmlDocument xmlDoc = new XmlDocument();

            // LOAD All information about Argument from XML file

            xmlDoc.Load(xmlRuleFile);
            XmlNode rootNode = xmlDoc.DocumentElement;

            foreach (XmlNode childNode in rootNode.ChildNodes)
            {
                PCArg newArg = new PCArg();
                newArg.name = childNode.Attributes["name"].Value.Trim();
                newArg.value = childNode.Attributes["value"].Value.Trim();
                lstArg.Add(newArg);
            }

            // CALC the values for all Arguments

            // . Random
            Random randomNumer = new Random();
            foreach (PCArg arg in lstArg)
            {
                if (arg.value.ToLower()== "random")
                {
                    arg.value = randomNumer.Next(10).ToString();
                }
            }
            
            // . Ruled Arguments
            /*
            foreach (PCArg arg in lstArg)
            {
                if (!Validator.isNumber(arg.value))
                {
                    foreach (PCArg argConst in lstArg)
                    { 
                        // Replace all argruments in the expression by the correlative values
                        if(Validator.isNumber(argConst.value))
                        {
                            arg.value = arg.value.Replace(argConst.name[0],argConst.value[0]);
                        }
                    }
                    arg.value = ((int)ExpressionClass.evaluateExp(arg.value)).ToString();
                }
            }
            /*/
            CalculateArgs(lstArg);
            // */

            // MERGE all to CodeNumber
            string sResultCode = "";
            for (int i = 0; i < lstArg.Count; i++)
            {
                sResultCode += lstArg[i].value;
            }

            // EXPORT the result;
            newPCode.CodeNumber = sResultCode;
            return newPCode;

        }

        internal static bool isPossibleCode(string sCodeNumber)
        {
            
            List<PCArg> lstArg = new List<PCArg>();
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(xmlRuleFile);
            XmlNode rootNode = xmlDoc.DocumentElement;

            // Load & set value for random arguments
            foreach (XmlNode childNode in rootNode.ChildNodes)
            {
                PCArg newArg = new PCArg();
                newArg.name = childNode.Attributes["name"].Value.Trim();
                newArg.value = childNode.Attributes["value"].Value.Trim();
                lstArg.Add(newArg);
            }

            for(int i = 0; i < lstArg.Count; i++)
            {
                if (lstArg[i].value.ToLower() == "random")
                {
                    lstArg[i].value = sCodeNumber[i].ToString();
                }
            }

            // Calculate the remain arguments..
           
            CalculateArgs(lstArg);
           
            // get ConfirmCodeNumber and compare
            string sConfirmCodeNumber = "";
            for (int i = 0; i < lstArg.Count; i++)
            {
                sConfirmCodeNumber += lstArg[i].value;
            }
            
            return (sCodeNumber == sConfirmCodeNumber);

        }

        private static void CalculateArgs(List<PCArg> lstArg)
        {
            foreach (PCArg arg in lstArg)
            {
                if (!Validator.isNumber(arg.value))
                {
                    foreach (PCArg argConst in lstArg)
                    {
                        // Replace all argruments in the expression by the correlative values
                        if (Validator.isNumber(argConst.value))
                        {
                            arg.value = arg.value.Replace(argConst.name[0], argConst.value[0]);
                        }
                    }
                    arg.value = ((int)ExpressionClass.evaluateExp(arg.value)).ToString();
                }
            }
        }
    
    }

    internal class PCArg
    {
        public string name;
        public string value;
    }

}   