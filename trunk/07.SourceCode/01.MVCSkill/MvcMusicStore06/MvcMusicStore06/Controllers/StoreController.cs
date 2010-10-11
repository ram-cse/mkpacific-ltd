using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcMusicStore06.ViewModels;
using MvcMusicStore06.Models;

namespace MvcMusicStore06.Controllers
{
    public class StoreController : Controller
    {
        MvcMusicStoreEntities storeDB = new MvcMusicStoreEntities();
        
        //
        // GET: /Store/Index

        public ActionResult Index()
        {
            // Tạo giá trị
            // var genres = new List<string> { "Rock", "Jazz", "Country", "Pop", "Disco" };
            var genres = from genre in storeDB.Genres
                         select genre.Name;

            // Gán vào biếw viewmodel (template cho view)
            // var viewModel = new StoreIndexViewModel {..}

            StoreIndexViewModel viewModel = new StoreIndexViewModel
            {
                NumberOfGenres = genres.Count(),
                Genres = genres.ToList()
            };

            // Truyền vào View
            return View(viewModel);
        }

        //
        // GET: /Store/Browse?Genre=DisCo

        public ActionResult Browse(string genre)
        {
            // Lấy giá trị truyền vào
            // string genreName = Server.HtmlEncode(Request.QueryString["genre"]);

            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);

            // Truyền các biến (Model) để xử lý
            //var genre = new Genre
            //{
            //    Name = genreName
            //};

            //var albums = new List<Album>();

            //albums.Add(new Album { Title = genreName + " Album 01" });
            //albums.Add(new Album { Title = genreName + " Album 02" });
            //albums.Add(new Album { Title = genreName + " Album 03" });
            
            // Truyền các biến Model cho view thông qua ViewModels

            var viewModel = new StoreBrowseViewModel{
                Genre = genreModel,
                Albums = genreModel.Albums.ToList()
            };

            return View(viewModel);
        }

        //
        // GET: /Store/Detail/5

        /*
        public string Detail(string name, int value)
        {
            return "detail: name = " + name + " & value = " + value;
        }
        // */
        public ActionResult Detail(int id)
        {
            var album = new Album { Title = "Sample Album" };            
            return View(album);
        }

    }
}
