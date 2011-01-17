using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MoneyPacificSite.ViewModels;
using MoneyPacificSite.Models.DAO;

namespace MoneyPacificSite.Models.BUS
{
    public class _SecurityBUS 
    {
        public List<TimeTable> GetList()
        {
            return _SecurityDAO.GetList();
        }
    }
}
