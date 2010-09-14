using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace P5.MoneyPacific
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MainService" in both code and config file together.
    public class MainService : IMainService
    {
        public string SendMessage(string smsMessage)
        {
            return "Get \"" + smsMessage + "\" Already. Reply from 0.0.0.0";
        }
    }
}
