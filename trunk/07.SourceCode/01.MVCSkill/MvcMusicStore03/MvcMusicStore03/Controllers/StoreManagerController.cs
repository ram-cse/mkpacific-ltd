using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcMusicStore03.Models;
using MvcMusicStore03.ViewModels;


namespace MvcMusicStore03.Controllers
{
    public class StoreManagerController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /StoreManager/

        public ActionResult Index()
        {
            var albums = storeDB.Albums.Include("Genre").Include("Artist").ToList();

            return View(storeDB.Albums);
        }

        //
        // GET: /StoreManager/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            var viewModel = new StoreManagerViewModel
            {
                Album = new Album(),
                Genres = storeDB.Genres.ToList(),
                Artists = storeDB.Artists.ToList()
            };

            return View(viewModel);
        } 

        //
        // POST: /StoreManager/Create

        // [HttpPost]
        // public ActionResult Create(FormCollection collection)

        [HttpPost]
        public ActionResult Create(Album album)
        {
            // TODO: Add insert logic here
           
            try
            {
                // TODO: Add insert logic here
                storeDB.AddToAlbums(album);
                storeDB.SaveChanges();

                //return RedirectToAction("Index");
                return Redirect("/");
            }
            catch
            {
                // Invalid - redisplay with errors
                var viewModel = new StoreManagerViewModel
                {
                    Album = album,
                    Genres = storeDB.Genres.ToList(),
                    Artists = storeDB.Artists.ToList()
                };

                return View(viewModel);
            }
        }
        
        //
        // GET: /StoreManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            var viewModel = new StoreManagerViewModel
            {
                Album = storeDB.Albums.Single(a => a.AlbumId == id),
                Genres = storeDB.Genres.ToList(),
                Artists = storeDB.Artists.ToList()
            };

            return View(viewModel);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var album = storeDB.Albums.Single(a => a.AlbumId == id);


            try
            {
                // TODO: SAVE
                UpdateModel(album, "Album"); // tự động update biến album vào table Album
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                // Nếu lưu không được thì giữ lại toàn bộ thông tin.
                var viewModel = new StoreManagerViewModel { 
                    Album = album,
                    Artists = storeDB.Artists.ToList(),
                    Genres = storeDB.Genres.ToList()
                };
             
                return View(viewModel);
            }
        }

        //
        // GET: /StoreManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            var album = storeDB.Albums.Single(a => a.AlbumId == id);
            return View(album);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, string confirmButton)
        {
            var album = storeDB.Albums
                .Include("OrderDetails").Include("Carts")
                .Single(a => a.AlbumId == id);

            storeDB.DeleteObject(album);
            storeDB.SaveChanges();
            return View("Deleted");
        }
    }
}
