using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificService.General
{
    public class Authorize : Attribute
    {
        public String Roles { get; set; }

        public String[] GetArrayRoles()
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