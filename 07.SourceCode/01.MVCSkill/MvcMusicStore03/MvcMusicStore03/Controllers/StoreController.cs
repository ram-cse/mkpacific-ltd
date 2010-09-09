using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcMusicStore03.ViewModels;
using MvcMusicStore03.Models;

namespace MvcMusicStore03.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        MusicStoreEntities storeDB = new MusicStoreEntities();

        public ActionResult Index()
        {
            var genres = from genre in storeDB.Genres
                         select genre.Name;
            var viewModel = new StoreIndexViewModel
            {
                   Genres = genres.ToList(),
                   NumberOfGenres = genres.Count()
            };
            return View(viewModel);

            /*
            var genres = new List<String> { "Rock", "Jazz", "Country", "Pop", "Disco" };
            
            // Create our view model
            // (this is a result for returning)
            var viewModel = new StoreIndexViewModel
            {
                NumberOfGenres = genres.Count,
                Genres = genres
            };
            return View(viewModel);
            // */

        }

        public ActionResult Browse(string genre)
        {
            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);

            var viewModel = new StoreBrowseViewModel
            {
                Genre = genreModel,
                Albums = genreModel.Albums.ToList()
            };

            return View(viewModel);
        }

        //
        // Get: /Store/Details/5
        public ActionResult Details(int id)
        {
            var album = storeDB.Albums.Single(a => a.AlbumId == id);
            return View(album);
        }

    }
}
