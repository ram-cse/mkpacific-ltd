using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security;
using System.Security.Principal;

namespace Merchant.Models
{
    public class MPAccess : System.Web.Mvc.AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            IPrincipal user = httpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                return false;
            }
                       
            if ((this.Roles.Length > 0) && (!this.Roles.Contains(ReturnUserRole(user.Identity.Name))))
            {
                return false;
            }

            return true;
        }

        private string ReturnUserRole(string name)
        {
            MPWebmasterEntities db = new MPWebmasterEntities();
            UserInRole role = db.UserInRoles.Single(m=>m.Username==name);
            return role.Role.RoleName;
        }


    }  

}