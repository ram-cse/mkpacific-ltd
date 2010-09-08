using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore
{
    public class StoreBrowseViewModel
    {
        public Genre genre{get;set;}
        public List<Album> albums { get; set; }
    }
}