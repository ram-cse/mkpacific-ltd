using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MvcKiemTra.Models;

namespace MvcKiemTra.ViewModels
{

    public class StoreBrowseViewModel
    {
        public Genre Genre { get; set; }
        public List<Album> Albums { get; set; }
    }
    
}