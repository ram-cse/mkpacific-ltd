using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MvcMusicStore03.Models;

namespace MvcMusicStore03.ViewModels
{
    public class StoreManagerViewModel
    {
        public Album Album { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Genre> Genres { get; set; }
    }
}