using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoneyPacificSrv.General;

namespace MoneyPacificSrv.Cmd
{
    public class MPLASCommand : IMPCommand
    {
        #region IMPCommand Members

        /// <summary>
        /// MPLAS: Trả ra thông chi tiết của lần cuối Money Pacific Collec the money
        /// args[0]: Phone của StoreUser hoặc StoreManager
        /// args[1]: MPLAS
        /// args[2]: PINStore
        /// </summary>
        [Authorize(Roles = "StoreManager, StoreUser")]
        public string Execute(string[] args)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}