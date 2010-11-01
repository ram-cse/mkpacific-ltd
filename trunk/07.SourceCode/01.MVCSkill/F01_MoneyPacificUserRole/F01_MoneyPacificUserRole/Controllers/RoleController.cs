using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using F01_MoneyPacificUserRole.Providers;
using F01_MoneyPacificUserRole.Models;

namespace F01_MoneyPacificUserRole.Controllers
{
    public class RoleController : Controller
    {
        //
        // GET: /Role/

        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Create()
        {
            ASPNETDBEntities1 db = new ASPNETDBEntities1();

            string roleName = "LeThanhDung";
            //aspnet_MPRoles newRole = db.aspnet_MPRoles.CreateObject();

            aspnet_MPRoles newRole = new aspnet_MPRoles();
            newRole.RoleName = roleName;
            newRole.LowerRoleNam = roleName.ToLower();

            db.aspnet_MPRoles.AddObject(newRole);

            db.SaveChanges();
            db.Connection.Close(); 
            return View();
        }

        [HttpPost]
        public ActionResult Create(aspnet_MPRoles model)
        {
            ViewData["Message"] = "Success!";
            MoneyPacificRoleProvider provider = new MoneyPacificRoleProvider();
            provider.CreateRole(model.RoleName);
            return View();
        }


    }
}
