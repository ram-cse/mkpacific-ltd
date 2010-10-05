using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificSrv
{
    public class MPMessageDTO
    {
        internal string name;
        internal string value;

        public MPMessageDTO()
        {
            name = "name";
            value = "value";
        }

        public MPMessageDTO(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        //public string ToString()
        //{
        //      return this.value;
        //}

        // public static string operator 
        // TODO:
    }
}