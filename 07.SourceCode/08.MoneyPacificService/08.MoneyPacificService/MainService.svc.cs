using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _08.MoneyPacificService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MainService" in code, svc and config file together.
    public class MainService : IMainService
    {
        public string SendMessage(string smsContent)
        {
            return MoneyPacificCore.GetRequest(smsContent);
        }
    }
}
