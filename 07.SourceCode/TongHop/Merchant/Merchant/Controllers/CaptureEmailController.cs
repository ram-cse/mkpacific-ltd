using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using Merchant.Models;

namespace Merchant.Controllers
{
    public class CaptureEmailController : Controller
    {
        //
        // GET: /CaptureEmail/

        MPWebmasterEntities db = new MPWebmasterEntities();

        public ActionResult Index(string id)
        {

            string[] list = id.Split(new string[]{"XXX"},StringSplitOptions.None);
            
            string type="";

            if (list[list.Length - 1] == "1")
                type = "Learn More";
            else if (list[list.Length - 1] == "2")
                type="Shop";
            else
                type= "Webmaster";

            EmailCapture email = new EmailCapture();
            email.Email = list[0];
            email.Type = type;

            db.EmailCaptures.AddObject(email);

            db.SaveChanges();


            return null;
        }

    }
}
