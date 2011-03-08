using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merchant.Models;
using Merchant.Helper;
namespace Merchant.Controllers
{
    [HandleError]
    public class viController : Controller
    {
        MPWebmasterEntities db = new MPWebmasterEntities();
       

        [ChildActionOnly]
        public ActionResult GetHeaderBox()
        {
            var text = db.Parameters.Single(p => p.Name == "HeaderText").Value;
            ViewData["HeaderText"] = text.ToString();
            return View();
        }








        public ActionResult Index()
        {
            LangText.LoadPortal("VI");
            ViewData["name"] = LangText.GetTextPortal("NAME");

            return View();
        }

        public ActionResult customer()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("customer.vi");
            ViewData["content"] = content;
            return View();
        }
        public ActionResult ministore()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("ministore.vi");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult children()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("children.vi");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult security()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("security.vi");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult bestsite()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("bestsite.vi");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult privacy()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("privacy.vi");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult tos()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("termofuse.vi");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult contact()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("contact.vi");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult licence()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("licence.vi");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult question()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("question.vi");
            ViewData["content"] = content;
            return View();
        }



        public ActionResult more()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("more.vi");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult demo()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("demo.vi");
            ViewData["content"] = content;
            return View();
        }


        public ActionResult About()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("about.vi");
            ViewData["content"] = content;
            return View();
        }


        public ActionResult sell()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("sell.vi");
            ViewData["content"] = content;
            return View();
 
        }
        public ActionResult recommend()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("recommend.vi");
            ViewData["content"] = content;
            return View();

        }
        public ActionResult createweb()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("createweb.vi");
            ViewData["content"] = content;
            return View();

        }

        public ActionResult buycash()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("buycash.vi");
            ViewData["content"] = content;
            return View();

        }


        public ActionResult buycredit()
        {
            LangText.LoadPortal("VI");
            string content = LangText.LoadConent("buycredit.vi");
            ViewData["content"] = content;
            return View();

        }


    }
}
