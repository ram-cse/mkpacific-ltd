using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SqlServer.Server;
using System.Data.SqlClient;


namespace P12_MPTrigger
{
    public class MPTrigger
    {
        public static void KiemTraLuuTruKH()
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            
            cmd.CommandText = "select * from inserted";

            SqlTriggerContext triggerContext = SqlContext.TriggerContext;
            switch (triggerContext.TriggerAction)
            {
                case TriggerAction.Insert:
                    SqlContext.Pipe.Send("Inserted");
                    SqlContext.Pipe.ExecuteAndSend(cmd);

                    break;
                case TriggerAction.Update:
                    SqlContext.Pipe.Send("Updated");
                    break;
                case TriggerAction.Delete:
                    SqlContext.Pipe.Send("Deleted");
                    break;
            }
        }

        public static void TriggerInsertPacificCode()
        {
            SqlTriggerContext triggerContext = SqlContext.TriggerContext;
            SqlConnection cnn;
            SqlCommand sqlCommand;

            if (triggerContext.TriggerAction == TriggerAction.Insert)
            {
                cnn = new SqlConnection("context connection = true");
                cnn.Open();

                sqlCommand = new SqlCommand();
                sqlCommand.Connection = cnn;
                sqlCommand.CommandText = "SELECT * from INSERTED";
                SqlContext.Pipe.Send("");
                cnn.Close();
            }
        }
    }
}
