using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyPacificBlackBox.DAO
{
    internal class Connection
    {
        private static MoneyPacificBlackBoxDataContext _connection = new MoneyPacificBlackBoxDataContext();
        internal static MoneyPacificBlackBoxDataContext Instance
        {
            get
            {
                // Test refesh bang cach nay                
                ///
                /// Hay gặp lỗi Connection bị đóng giữa chừng...
                /// => không sử dụng
                //_connection.Connection.Close();
                //_connection.Connection.Close();
                _connection = new MoneyPacificBlackBoxDataContext();
                return _connection;
            }
        }
    }
}