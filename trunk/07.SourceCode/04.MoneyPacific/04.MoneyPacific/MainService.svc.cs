using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using _04.MoneyPacific.Controller;

namespace _04.MoneyPacific
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MainService" in code, svc and config file together.
    public class MainService : IMainService
    {
        public string SendSms(string smsMessage)
        {
            SmsSyntaxController smsController = new SmsSyntaxController();
            return smsController.GetMessage(smsMessage);
        }
    }
}
