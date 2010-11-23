using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace F5_MoneyPacificSite.Models.DAO
{
    public class AgentDAO
    {
        internal static List<Agent> GetList()
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            List<Agent> lstAgent = db.Agents.ToList();
            db.Connection.Close();
            return lstAgent;
         }


        internal static bool AddItem(Agent newAgent)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            db.Agents.AddObject(newAgent) ;
            db.SaveChanges();
            db.Connection.Close();
            return true;
        }

        internal static Agent GetItem(int id)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            Agent existAgent = db.Agents
                .Where(a => a.Id == id)
                .SingleOrDefault();
            db.Connection.Close();
            return existAgent;
        }

        internal static bool Update(Agent agent)
        {
            MoneyPacificEntities db = new MoneyPacificEntities();
            
            Agent existAgent = db.Agents
                .Where(a => a.Id == agent.Id)
                .SingleOrDefault();

            existAgent.Address = agent.Address ?? null;
            existAgent.Comment = agent.Comment;
            existAgent.Email = agent.Email;
            existAgent.FistName = agent.FistName;            
            existAgent.LastName = agent.LastName;
            existAgent.Password = agent.Password;
            existAgent.Phone = agent.Phone;
            existAgent.StatusId = agent.StatusId;
            existAgent.Username = agent.Username;

            db.SaveChanges();
            db.Connection.Close();
            return true;
        }
    }
}