using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{
    public partial class User
    {
        public void CopyFrom(User entity)
        {
            this.Username = entity.Username;
            this.Password = entity.Password;

            this.Firstname = entity.Firstname;
            this.Lastname = entity.Lastname;

            this.Email = entity.Email;
            
            this.CreateDate = entity.CreateDate;            
            this.LastVisitDate = entity.LastVisitDate;
            this.Block = entity.Block;
            
        }
    }
}
