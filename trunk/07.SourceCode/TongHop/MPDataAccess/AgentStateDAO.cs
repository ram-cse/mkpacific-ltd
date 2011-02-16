using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{
    public class AgentStateDAO
    {
        public static AgentState GetObject(int id) 
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            AgentState existAgentState = mpdb.AgentStates
                .Where(a => a.Id == id)
                .Single<AgentState>();
            mpdb.Connection.Close();
            return existAgentState;
        }

        public static bool AddNew(AgentState entity)
        {
            throw new Exception("chua lam!...");
        }

        public static bool Update(AgentState entity)
        {
            throw new Exception("chua lam!...");
        }

        public static bool Remove(int id)
        {
            throw new Exception("chua lam!...");
        }

        public static bool IsExist()
        {
            throw new Exception("chua lam!...");
        }

        public static bool IsExist(bool condition)
        {
            throw new Exception("chua lam!...");
        }

        public static List<AgentState> GetList()
        {
            MoneyPacificDataContext mpdb = new MoneyPacificDataContext();
            List<AgentState> lstResult = new List<AgentState>();
            if (mpdb.Agents.Any())
            {
                lstResult = mpdb.AgentStates.ToList();
            }
            mpdb.Connection.Close();
            return lstResult;
        }

        public static AgentState[] GetArray()
        {
            throw new Exception("chua lam!...");
        }


        
    }
}
