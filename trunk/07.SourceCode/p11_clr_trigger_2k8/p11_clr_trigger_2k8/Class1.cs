using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.SqlServer.Server;

namespace P9_SampleClrTrigger
{
    public class CLRTrigger
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

        public static void TestClrTrigger()
        {
            SqlTriggerContext triggerContext = SqlContext.TriggerContext;
            switch (triggerContext.TriggerAction)
            {
                case TriggerAction.Insert:
                    SqlContext.Pipe.Send("INSERTED... ABC...");
                    break;
                case TriggerAction.Update:
                    SqlContext.Pipe.Send("UPDATED... ABC...");
                    break;
                case TriggerAction.Delete:
                    SqlContext.Pipe.Send("DELETED... ABC...");
                    break;
            }
        }
    }
}
