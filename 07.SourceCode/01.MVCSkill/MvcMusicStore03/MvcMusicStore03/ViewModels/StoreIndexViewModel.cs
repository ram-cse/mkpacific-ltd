using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore03.ViewModels
{
    public class StoreIndexViewModel
    {
        public int NumberOfGenres { get; set; }
        public List<String> Genres { get; set; }
    }
}