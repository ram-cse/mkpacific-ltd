using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Merchant.Models
{
    public class MyRoleProvider:RoleProvider
    {
        MPWebmasterEntities db = new MPWebmasterEntities();

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            string rolename = roleNames[0];

            var checkit = db.Roles.Single(c=>c.RoleName == rolename);


            UserInRole role = new UserInRole();
            role.Username = usernames[0];
            role.RoleId = checkit.Id;

            db.UserInRoles.AddObject(role);

            db.SaveChanges();
            
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
            Role role = new Role();
            role.RoleName = roleName;
            db.Roles.AddObject(role);
            db.SaveChanges();

        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            //var checkit = db.UserInRoles.Single(o=>o.Username == username);
            var checkit = from c in db.UserInRoles
                          where c.Username == username
                          select c;
            if (checkit.Any())
            {
                if (checkit.First().Role.RoleName == roleName)
                    return true;
                else return false;

            }
            else
                return false;

        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}