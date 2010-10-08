using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using P7_MVCNhactt.Models;
using P7_MVCNhactt.ViewModels;

namespace P7_MVCNhactt.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/
        MvcMusicStoreEntities storeDB = new MvcMusicStoreEntities();

        public ActionResult Index()
        {
            var viewModel = new StoreIndexViewModel
            {
                NumberOfGenre = storeDB.Genres.Count(),
                Genres = storeDB.Genres.ToList<Genre>()
            };
            return View(viewModel);
        }
       
        public ActionResult Browse()
        {
               
            return View();
        }

    }
}
