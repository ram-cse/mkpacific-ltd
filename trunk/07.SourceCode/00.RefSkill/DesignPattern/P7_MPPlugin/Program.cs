using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data.Common;
using System.Reflection;

namespace P7_MPPlugin
{
    class Program
    {
        static void Main(string[] args)
        {

            XmlDocument doc = new XmlDocument();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string xmlPath = path + "\\Plugin.xml";
            doc.Load(xmlPath);

            XmlElement root = doc.DocumentElement;
            int iCount = root.ChildNodes.Count;
            
            List<string> lstPluginName = new List<string>();
            for (int i = 0; i < iCount; i++)
            { 
            }


            Assembly a = Assembly.Load("P7_MPPlugin");            
            Type t = a.GetType("P7_MPPlugin.BuyPlugin");

            IMPPlugin iCommand = (IMPPlugin) Activator.CreateInstance(t);
            iCommand.Execute();
            //Console.WriteLine(iCommand.GetType());
        }
    }
}
