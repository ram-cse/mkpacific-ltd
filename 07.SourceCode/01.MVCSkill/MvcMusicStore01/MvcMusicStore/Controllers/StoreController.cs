using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/Index

        public ActionResult Index()
        {
            //return "Return from Store.Index()";
            // Create  a list of genres

            var genres = new List<String> { "Rock", "Jazz", "Country", "Pop", "Disco" };
            var viewModel = new StoreIndexViewModel
            {
                NumberOfGenres = genres.Count(),
                Genres = genres
            };

            return View(viewModel);
        }

        //
        // GET: /Store/Browse/

        public ActionResult Browse()
        {
            //return "Return from Store.Browse";

            /*
            String message = "Store.Browse, Genre = " +
                Server.HtmlEncode(Request.QueryString["Genre"]);
            return Server.HtmlEncode(message);
            //*/

            string genreName = Server.HtmlEncode(Request.QueryString["Genre"]);
            
            var genre = new Genre
            {
                Name = genreName,
            };

            var album = new List<Album>();

            album.Add(new Album { Title = genreName + "Album 1" });
            album.Add(new Album { Title = genreName + "Album 2" });
            album.Add(new Album { Title = genreName + "Album 3" });

            var viewModel = new StoreBrowseViewModel
            {
                genre = genre,
                albums = album
            };

            return View(viewModel);
            

        }
        
        //
        // GET: /Store/Details/5

        public String Details(int id)
        {
            //return "Return from Store.Details()";
            String message = "Store.Details, ID = " + id;
            return Server.HtmlEncode(message);

        }

    }
}
