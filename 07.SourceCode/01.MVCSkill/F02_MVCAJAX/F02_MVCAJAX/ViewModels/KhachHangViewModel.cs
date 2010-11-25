using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using F02_MVCAJAX.Models;

namespace F02_MVCAJAX.ViewModels
{
    public class KhachHangViewModel
    {
        public List<KhachHang> KhachHangs { get; set; }
        public int SoLuong { get; set; }
    }
}