using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificBlackBox.DAO
{
    internal class Connection
    {
        private static MoneyPacificBlackBoxDataContext _connection = new MoneyPacificBlackBoxDataContext();
        internal static MoneyPacificBlackBoxDataContext Instance
        {
            get { return _connection; }
        }
    }
}