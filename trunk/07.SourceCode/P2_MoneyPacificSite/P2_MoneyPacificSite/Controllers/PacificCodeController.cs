using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using P2_MoneyPacificSite.Models;

namespace P2_MoneyPacificSite.Controllers
{
    public class PacificCodeController : Controller
    {
        //
        // GET: /PacificCode/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            MoneyPacificDataContext db = new MoneyPacificDataContext();
            var viewModel = db.PacificCodes.Where(p => p.ID == id).Single<PacificCode>();
            return View(viewModel);
        }

    }
}
