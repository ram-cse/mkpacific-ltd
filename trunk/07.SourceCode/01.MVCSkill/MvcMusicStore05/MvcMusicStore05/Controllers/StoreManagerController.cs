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
            var viewModel = new StoreManagerViewModel { 
                Album = new Album(),
                Genres = storeDB.Genres.ToList(),
                Artists = storeDB.Artists.ToList()
            };

            return View(viewModel);
        } 

        //
        // POST: /StoreManager/Create

        [HttpPost]
        //public ActionResult Create(FormCollection collection)
        public ActionResult Create(Album album)
        {
            try
            {
                // TODO: Add insert logic here

                storeDB.AddToAlbums(album);
                storeDB.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("/");
            }
            catch
            {
                // Invalid - ReDisplay with Errors
                var viewModel = new StoreManagerViewModel { 
                    Album = album,
                    Artists = storeDB.Artists.ToList(),
                    Genres = storeDB.Genres.ToList()
                };
                return View();
            }
        }
        
        //
        // GET: /StoreManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            // Lay gia tri và truyền vào biến viewModel
            var viewModel = new StoreManagerViewModel
            {
                Album = storeDB.Albums.Single(a => a.AlbumId == id),
                Artists = storeDB.Artists.ToList(),
                Genres = storeDB.Genres.ToList()
            };

            // Trả kết quả ra cho View
            return View(viewModel);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            // Lấy thông tin đối tượng cần cập nhật thông qua ID
            var album = storeDB.Albums.Single(a => a.AlbumId == id);

            try
            {
                // TODO: Add update logic here
                // Cập nhật thông tin mới
                UpdateModel(album, "Album"); // cap nhật doi tuong Album tu Model
                storeDB.SaveChanges();

                // Lưu xong trả về trang Index
                return RedirectToAction("Index");
                
            }
            catch
            {
                // Trả lại trang View nếu không cập nhật được
                var viewModel = new StoreManagerViewModel
                {
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
