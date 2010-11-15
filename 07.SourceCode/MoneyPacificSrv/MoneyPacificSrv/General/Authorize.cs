using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSrv.General
{
    public class Authorize : Attribute
    {
        public string Roles { get; set; }
        public string[] GetArrayRoles()
        {
            string[] result = this.Roles.Split(',');
            for (int i = 0; i < result.Count(); i++)
            {
                result[i] = result[i].Trim();
            }
            return result;
        }
    }
}