using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{
    public class AgentDAO
    {
        
        public static Agent GetObject(Guid userId)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            Agent existAgent = mpdb.Agents
                .Where(a => a.UserId.Equals(userId))
                .Single<Agent>();
            return existAgent;            
        }

        public static bool AddNew(Agent entity)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();

            mpdb.Agents.InsertOnSubmit(entity);
            mpdb.SubmitChanges();

            mpdb.Connection.Close();
            return true;
        }

        public static bool Update(Agent entity)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();

            Agent existAgent = DataAccessLayer.GetConnection.Agents
                .Where(p => p.UserId.Equals(entity.UserId))
                .SingleOrDefault();

            existAgent.Address          = entity.Address;
            //existAgent.Block            = entity.Block;
            //existAgent.CreateDate       = entity.CreateDate;
            //existAgent.Email            = entity.Email;
            //existAgent.FirstName        = entity.FirstName;
            //existAgent.LastName         = entity.LastName;
            //existAgent.LastVisitDate    = entity.LastVisitDate;
            //existAgent.Password         = entity.Password;
            existAgent.Phone            = entity.Phone;
            existAgent.StatusId         = entity.StatusId;
            //existAgent.Username         = entity.Username;

            DataAccessLayer.GetConnection.SubmitChanges();
            return true;
        }

        public static bool Remove(Guid id)
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();

            Agent existAgent = DataAccessLayer.GetConnection.Agents
                .Where(a => a.UserId.Equals(id)).Single<Agent>();
            DataAccessLayer.GetConnection.Agents.DeleteOnSubmit(existAgent);
            DataAccessLayer.GetConnection.SubmitChanges();
            return true;
        }

        public bool IsExist(Agent entity)
        {
            // TODO:
            return true;
        }

        public static List<Agent> GetList()
        {
            // TODO:
            // return new List<Agent>();
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            List<Agent> result = new List<Agent>();
            if (mpdb.Agents.Any())
            {
                result = mpdb.Agents.ToList<Agent>();
            }            
            mpdb.Connection.Close();
            return result;

        }

        public List<Agent> GetList(bool dk)
        {
            // TODO:
            return new List<Agent>();
        }

        public Agent[] GetArray()
        {
            // TODO:
            Agent[] arrResult = { new Agent() };
            return arrResult;
        }

        public Agent[] GetArray(bool condition)
        {
            // TODO:
            Agent[] arrResult = { new Agent() };
            return arrResult;
        }       
    }
}
