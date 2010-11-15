using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSrv.DTO
{
    #region UserDTO

    public partial class StoreUser : IUser
    {
        public string GetRoles()
        { 
            return this.GetType().Name;
        }
    }

    public partial class StoreManager : IUser
    {
        public string GetRoles()
        {
            return this.GetType().Name;
        }
    }

    public partial class Customer : IUser
    {
        public string GetRoles()
        {
            return this.GetType().Name;
        }
    }

    #endregion
}