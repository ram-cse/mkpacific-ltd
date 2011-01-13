using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{    
    public class DataAccessLayer
    {
        private static MoneyPacificDataContext _connection = new MoneyPacificDataContext();

        public static MoneyPacificDataContext GetConnection
        {
            get 
            {
                //_connection.Connection.Close();
                _connection.Connection.Open();
                _connection = new MoneyPacificDataContext();
                return _connection;
            }
        }
    }
}
