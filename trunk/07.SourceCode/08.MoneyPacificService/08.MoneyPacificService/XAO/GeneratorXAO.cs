using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Xml;
using System.Xml.Linq;

namespace _08.MoneyPacificService.XAO
{
    public class GeneratorXAO
    {
        private void LoadXMLFile(string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            XmlNode nodeRoot = xmlDoc.DocumentElement;
            
            // Load Rule lên theo cấu trúc (chưa xác định), sẽ viết sau
        }
    }
}