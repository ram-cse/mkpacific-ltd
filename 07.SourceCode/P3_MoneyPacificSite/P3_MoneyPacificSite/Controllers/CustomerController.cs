using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using P3_MoneyPacificSite.Models;
using P3_MoneyPacificSite.ViewModels;

namespace P3_MoneyPacificSite.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {            
            MoneyPacificDataContext db = new MoneyPacificDataContext();
            var viewModel = db.Customers.Where(c => c.ID == 1).Single<Customer>();
            return View(viewModel);
        }

        public ActionResult Browse(int id)
        {
            MoneyPacificDataContext db = new MoneyPacificDataContext();

            List<PacificCode> lstPc = db.PacificCodes.Where(p => p.CustomerID == id).ToList<PacificCode>();
            // Kiểm tra thông tin đăng nhập, truyền vào ID
            var viewModel = new CustomerBrowseViewModel
            {
                PacificCodes = lstPc,
                NumberOfPacificCode = lstPc.Count()
            };

            return View(viewModel);
        }
    }
}
