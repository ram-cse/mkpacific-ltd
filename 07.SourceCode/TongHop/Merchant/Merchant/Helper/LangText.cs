using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merchant.Models;
using System.Configuration;
using System.Xml;
using System.IO;

namespace Merchant.Helper
{
    
    public class TextName
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public static class LangText
    {
        public static string Lang = "";
        public static TextName[] currentLang;
        public static MPWebmasterEntities db = new MPWebmasterEntities();
        public static TextName[] ArrayEN;
        public static TextName[] ArrayVI;
        static string path = "";

        public static void Load(string username)
        {
            try
            {
                db = new MPWebmasterEntities();
                db.Connection.Open();
                var setting = db.Settings.Single(s => s.Webmaster.Username == username);
                if (setting.Language == "VI")
                {
                    Lang = "VI";
                }
                else if (setting.Language == "EN")
                {
                    Lang = "EN";
                }

               
            }
            catch (Exception e)
            {
                Lang = "VI";//default languages
            }

            if(Lang == "EN")
                path = AppDomain.CurrentDomain.BaseDirectory + "\\Langs\\EN.xml";
            else if (Lang == "VI")
                path = AppDomain.CurrentDomain.BaseDirectory + "\\Langs\\VI.xml";

            //Load languages file
            XmlDocument doc = new XmlDocument();
                
            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            XmlNodeList list = root.ChildNodes;
            if(Lang == "EN")
                ArrayEN = new TextName[list.Count];
            else if(Lang=="VI")
                ArrayVI = new TextName[list.Count];
            int i = 0;
            foreach (XmlNode n in list)
            {
                if (Lang == "EN")
                {
                    ArrayEN[i] = new TextName();
                    ArrayEN[i].Name = n.Attributes[0].InnerText;
                    ArrayEN[i].Value = n.Attributes[1].InnerText;
                }
                else if (Lang == "VI")
                {
                    ArrayVI[i] = new TextName();
                    ArrayVI[i].Name = n.Attributes[0].InnerText;
                    ArrayVI[i].Value = n.Attributes[1].InnerText;
 
                }
                i++;

            }
            currentLang = new TextName[list.Count];

            if (Lang == "EN")
            {
                currentLang = ArrayEN;
            }
            else
            {
                currentLang = ArrayVI;
            }

        }

        public static string GetText(string name)
        {
            
            for (int i = 0; i < currentLang.Length; i++)
            {
                if (currentLang[i].Name == name)
                    return currentLang[i].Value;
 
            }
            return "No Text";

        }



        public static void LoadPortal(string language)
        {

            path = AppDomain.CurrentDomain.BaseDirectory + "\\Langs\\" + language + ".xml";
            Lang = language;

            //Load languages file
            XmlDocument doc = new XmlDocument();

            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            XmlNodeList list = root.ChildNodes;
            if (Lang == "EN")
                ArrayEN = new TextName[list.Count];
            else if (Lang == "VI")
                ArrayVI = new TextName[list.Count];
            int i = 0;
            foreach (XmlNode n in list)
            {
                if (Lang == "EN")
                {
                    ArrayEN[i] = new TextName();
                    ArrayEN[i].Name = n.Attributes[0].InnerText;
                    ArrayEN[i].Value = n.Attributes[1].InnerText;
                }
                else if (Lang == "VI")
                {
                    ArrayVI[i] = new TextName();
                    ArrayVI[i].Name = n.Attributes[0].InnerText;
                    ArrayVI[i].Value = n.Attributes[1].InnerText;

                }
                i++;

            }
            currentLang = new TextName[list.Count];

            if (Lang == "EN")
            {
                currentLang = ArrayEN;
            }
            else
            {
                currentLang = ArrayVI;
            }

        }

        public static string GetTextPortal(string name)
        {

            for (int i = 0; i < currentLang.Length; i++)
            {
                if (currentLang[i].Name == name)
                    return currentLang[i].Value;

            }
            return "No Text";

        }


        public static string LoadConent(string Name)
        {
            string filename = "";
            string lang = Name.Substring(Name.Length - 2, 2);
            if (lang == "vi")
            {
                filename = AppDomain.CurrentDomain.BaseDirectory + "\\Langs\\VI\\" + Name;
            }
            else
                filename = AppDomain.CurrentDomain.BaseDirectory + "\\Langs\\EN\\" + Name;
            StreamReader reader = File.OpenText(filename);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
        }
       

       
    }
}