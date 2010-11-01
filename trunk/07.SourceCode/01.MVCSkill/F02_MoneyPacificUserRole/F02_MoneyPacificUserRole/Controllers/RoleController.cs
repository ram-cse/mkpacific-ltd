using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F02_MoneyPacificUserRole.Models;

namespace F02_MoneyPacificUserRole.Controllers
{
    public class RoleController : Controller
    {
        //
        // GET: /Roles/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ASPNETDBEntities db = new ASPNETDBEntities();
            aspnet_Roles newRole = new aspnet_Roles();
            newRole.RoleName = "QuanTriVien";
            newRole.LoweredRoleName = "quantrivien";
            
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(aspnet_Roles model)
        {

            return View();
        }

    }
}
