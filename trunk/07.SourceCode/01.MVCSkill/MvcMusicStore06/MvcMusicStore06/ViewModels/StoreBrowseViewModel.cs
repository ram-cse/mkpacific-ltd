using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MvcMusicStore06.Models;

namespace MvcMusicStore06.ViewModels
{
    public class StoreBrowseViewModel
    {
        public Genre Genre { get; set; }
        public List<Album> Albums { get; set; }
    }
}