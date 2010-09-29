using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcMusicStore05.Models;
using MvcMusicStore05.ViewModels;

namespace MvcMusicStore05.Controllers
{
    public class StoreManagerController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        //
        // GET: /StoreManager/

        public ActionResult Index()
        {
            // Lấy giá trị từ DB, cũng là viewModel
            var albums = storeDB.Albums.Include("Genre").ToList();

            return View(albums);
        }

        //
        // GET: /StoreManager/Details/5

        public ActionResult Details(int id)
        {
            // Lay gia tri (đã lấy theo ID)
            // Truyen vao ViewModel
        
            var viewModel = new StoreManagerViewModel
            {
                Album = storeDB.Albums.Single(a=>a.AlbumId == id),
                Genres = storeDB.Genres.ToList(),
                Artists = storeDB.Artists.ToList()
            };
            
            // Xuat ra view
            return View(viewModel);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /StoreManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /StoreManager/Edit/5

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
        // GET: /StoreManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /StoreManager/Delete/5

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
