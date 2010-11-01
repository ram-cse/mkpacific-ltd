using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Security;
using F01_MoneyPacificUserRole.Models;

namespace F01_MoneyPacificUserRole.Providers
{
    public class MoneyPacificRoleProvider : RoleProvider
    {
        // Summary
        // MoneyPacific-AddUserToRoles
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            // throw new NotImplementedException();
            ASPNETDBEntities1 db = new ASPNETDBEntities1();

            //aspnet_MPRoles newRole = db.aspnet_MPRoles.CreateObject();

            aspnet_MPRoles newRole = new aspnet_MPRoles();
            newRole.RoleName = roleName;
            newRole.LowerRoleNam = roleName.ToLower();

            db.aspnet_MPRoles.AddObject(newRole);
            //db.SaveChanges();
            db.Connection.Close();            
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string Description
        {
            get
            {
                return base.Description;
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string[] GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();            
        }

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override string Name
        {
            get
            {
                return base.Name;
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

}