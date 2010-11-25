using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MvcKiemTra.Models;

namespace MvcKiemTra.ViewModels
{
    public class StoreManagerViewModel
    {
        public Album Album { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Genre> Genres { get; set; }

        
    }
}