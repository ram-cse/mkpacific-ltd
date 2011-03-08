using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merchant.Helper;

namespace Merchant.Controllers
{
    public class enController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult customer()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("customer.en");
            string contentPanel = LangText.LoadConent("customerPanel.en");
            ViewData["contentPanel"] = contentPanel;
            
            return View();
        }
        public ActionResult ministore()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("ministore.en");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult children()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("children.en");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult security()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("security.en");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult bestsite()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("bestsite.en");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult privacy()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("privacy.en");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult tos()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("termofuse.en");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult contact()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("contact.en");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult licence()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("licence.en");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult question()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("question.en");
            ViewData["content"] = content;
            return View();
        }



        public ActionResult more()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("more.en");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult demo()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("demo.en");
            ViewData["content"] = content;
            return View();
        }



        public ActionResult About()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("about.en");
            ViewData["content"] = content;
            return View();
        }

        public ActionResult recommend()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("recommend.en");
            ViewData["content"] = content;
            return View();

        }
        public ActionResult createweb()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("createweb.en");
            ViewData["content"] = content;
            return View();

        }

        public ActionResult buycash()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("buycash.en");
            ViewData["content"] = content;
            return View();

        }


        public ActionResult buycredit()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("buycredit.en");
            ViewData["content"] = content;
            return View();

        }

        public ActionResult sell()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("sell.en");
            ViewData["content"] = content;
            return View();

        }
        public ActionResult install()
        {
            LangText.LoadPortal("EN");
            string content = LangText.LoadConent("install.en");
            ViewData["content"] = content;
            return View();

        }

    }
}
