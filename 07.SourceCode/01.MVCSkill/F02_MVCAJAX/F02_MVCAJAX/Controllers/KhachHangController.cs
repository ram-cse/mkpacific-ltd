using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using F02_MVCAJAX.ViewModels;
using F02_MVCAJAX.Models;

namespace F02_MVCAJAX.Controllers
{
    public class KhachHangController : Controller
    {
        //
        // GET: /Agent/

        MoneyPacificEntities storeDB = new MoneyPacificEntities();
        public ActionResult Index()
        {
            var model = new KhachHangViewModel
            {
                KhachHangs = storeDB.KhachHangs.ToList<KhachHang>(),
                SoLuong = storeDB.KhachHangs.Count()
            };
            return View(model);
        }

        //
        // GET: /Agent/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Agent/Create

        public ActionResult Create()
        {
            var model = new KhachHang();
            return View(model);
        } 

        //
        // POST: /Agent/Create

        [HttpPost]
        public ActionResult Create(KhachHang obj)
        {
            var newKhachHang = new KhachHang();
            newKhachHang.Username = obj.Username;
            newKhachHang.Password = obj.Password;
            newKhachHang.Description = obj.Description;
            newKhachHang.Email = obj.Email;

            storeDB.KhachHangs.AddObject(newKhachHang);
            storeDB.SaveChanges();

            return RedirectToAction("Index");
        }
        
        //
        // GET: /Agent/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Agent/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Agent/Delete/5
 
        public ActionResult Delete(int id)
        {
            KhachHang existKH = storeDB.KhachHangs
                .Where(k => k.Id == id)
                .SingleOrDefault();
            storeDB.KhachHangs.DeleteObject(existKH);
            storeDB.SaveChanges();

            var result = new KhachHangViewModel
            {
                KhachHangs = storeDB.KhachHangs.ToList<KhachHang>(),
                SoLuong = storeDB.KhachHangs.Count()
            };
            return Json(result);
        }

        //
        // POST: /Agent/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
