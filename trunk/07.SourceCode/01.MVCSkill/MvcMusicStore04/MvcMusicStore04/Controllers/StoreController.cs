using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore04.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/Index

        public string Index()
        {
            return "Hello from Store.Index()";
        }

        //
        // GET: /Store/Browse

        public string Browse()
        {
            string message = "Store.Browse, Genre = " +
                Server.HtmlEncode(Request.QueryString["genre"]);
            return Server.HtmlEncode(message);
        }
        
        //
        // GET: /Store/Details/5

        public string Details(int id)
        {
            string message = "Store.Details, ID = " + id;
            return Server.HtmlEncode(message);

        }

    }
}
