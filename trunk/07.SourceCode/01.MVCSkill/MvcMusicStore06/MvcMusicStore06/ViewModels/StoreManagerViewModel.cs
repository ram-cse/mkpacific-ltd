using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MvcMusicStore06.Models;


namespace MvcMusicStore06.ViewModels
{
    public class StoreManagerViewModel
    {
        public Album Album { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Genre> Genres { get; set; }
    }
}