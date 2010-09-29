using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MvcMusicStore05.Models;

namespace MvcMusicStore05.ViewModels
{
    public class StoreBrowseViewModel
    {
        public Genre Genre { get; set; }
        public List<Album> Albums { get; set; }
    }
}