using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Sql;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Xml;
using System.IO;

namespace P8_SampleCLRTrigger
{
    

    
    class HWTrigger
    {
        public static void DropTableTrigger()
        {
            SqlTriggerContext triggContext = SqlContext.TriggerContext;

            switch (triggContext.TriggerAction)
            { 
                case TriggerAction.DropTable:
                    SqlContext.Pipe.Send("Table dropped! Here's EventData: ");
                    SqlContext.Pipe.Send(triggContext.EventData.Value);
                    break;
                default:
                    SqlContext.Pipe.Send("Something happened! Here's EventData: ");
                    SqlContext.Pipe.Send(triggContext.EventData.Value);
                    break;
            }
        }

        /*
        // This is the originall template for Trigger metadat. Note that is a table - specific ..

        [Microsoft.SqlServer.Server.SqlTrigger(Name = "AuditCommon", Event = "FOR UPDATE, INSERT, DELETE")]
        public static void AuditCommon()
        {
            try
            {
#if(DEBUG)
                EmitDebugMessage("Enter Trigger");
#endif
            }
            catch (Exception ex)
            {
                throw;
            }
        }

#if(DEBUG)

        private static void EmitDebugMessage(string message)
        {
            SqlContext.Pipe.Send(message);
        }
#endif
         //* */
    }
    

}
