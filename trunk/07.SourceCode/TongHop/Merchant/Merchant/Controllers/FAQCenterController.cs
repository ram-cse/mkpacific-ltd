using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Merchant.Models;

namespace Merchant.Controllers
{
    public class FAQCenterController : Controller
    {
        //
        // GET: /FAQCenter/
        public MPWebmasterEntities db = new MPWebmasterEntities();

        public ActionResult Index()
        {
            string filename = "";
            try
            {
                var setting = db.Settings.Single(s => s.Webmaster.Username == User.Identity.Name);
                if (setting.Language == "VI")
                {
                    filename = AppDomain.CurrentDomain.BaseDirectory + "\\FAQ\\FAQ.vi";
                }
                else if (setting.Language == "EN")
                {
                    filename = AppDomain.CurrentDomain.BaseDirectory + "\\FAQ\\FAQ.en";
                }


            }
            catch (Exception e)
            {
                filename = AppDomain.CurrentDomain.BaseDirectory + "\\FAQ\\FAQ.vi";//default languages
            }

            StreamReader reader = new StreamReader(filename);
            string content = reader.ReadToEnd();
                       
            ViewData["content"] = content;
            return View();
        }

       
    }
}
