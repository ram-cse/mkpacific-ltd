using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanQuyenDemo
{
    class AuthorizeAttribute : Attribute
    {
        public string Roles { get; set; }
    }
}
