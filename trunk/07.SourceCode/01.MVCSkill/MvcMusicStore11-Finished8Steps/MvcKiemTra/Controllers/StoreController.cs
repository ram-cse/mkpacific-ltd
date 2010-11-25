using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcKiemTra.ViewModels;
using MvcKiemTra.Models;

namespace MvcKiemTra.Controllers
{
    public class StoreController : Controller
    {
        MvcStoreEntities storeDB = new MvcStoreEntities();
        //
        // GET: /Store/

        public ActionResult Index()
        {
            // Retrieve list of Genres from database
            var genres = from genre in storeDB.Genres
                         select genre.Name;

            // Set up our ViewModel
            var viewModel = new StoreIndexViewModel()
            {
                Genres = genres.ToList(),
                NumberOfGenres = genres.Count()
            };

            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/Browse
        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = storeDB.Genres
                .Include("Albums")
                .Single(g => g.Name == genre);

            var viewModel = new StoreBrowseViewModel()
            {
                Genre = genreModel,
                Albums = genreModel.Albums.ToList()
            };

            return View(viewModel);
        }

        //
        // GET: /Store/Details        
        public ActionResult Details(int id)
        {
            var album = storeDB.Albums.Single(a => a.AlbumId == id);
            return View(album);
        }
    }
}
