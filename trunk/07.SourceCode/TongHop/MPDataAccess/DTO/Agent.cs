using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{
    public partial class Agent
    {
        public void CopyFrom(Agent entity)
        {
            // this.UserId = // ..
            this.StatusId = entity.StatusId;
            this.Phone = entity.Phone;
            this.Address = entity.Address;
        }
    }
}
