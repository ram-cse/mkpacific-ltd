using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKiemTra.ViewModels
{
    public class StoreIndexViewModel
    {
        public int NumberOfGenres { get; set; }
        public List<string> Genres { get; set; }
    }
}