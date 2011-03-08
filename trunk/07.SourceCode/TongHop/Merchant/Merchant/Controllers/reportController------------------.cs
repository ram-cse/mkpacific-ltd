using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merchant.Models;
using System.Text;
namespace Merchant.Controllers
{

     [MPAccess(Roles = "Webmaster")]
    public class reportController : Controller
    {
        //
        // GET: /report/
        public MPWebmasterEntities StoreDb = new MPWebmasterEntities();
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult moneyview()
        {
            string userlogin = User.Identity.Name;
            Earning earning = StoreDb.Earnings.Single(m=>m.Webmaster.Username == userlogin);
            Payment payment = StoreDb.Payments.Single(mm=>mm.Webmaster.Username == userlogin);

            EarningViewModel model = new EarningViewModel() 
            { earning = earning,payment = payment};
            return View(model);
        }
        
        public ActionResult setWithdraw()
        {
            string userlogin = User.Identity.Name;
            Earning earning = StoreDb.Earnings.Single(m => m.Webmaster.Username == userlogin);
            
            if (earning.Amount >= 500000)
            {
                earning.Status = 1;
                earning.DateWithDraw = DateTime.Now;
            }
            StoreDb.SaveChanges();

            return RedirectToAction("moneyview");

        }
        
        public ActionResult details()
        {
            string userlogin = User.Identity.Name;

            var orderReport = from m in StoreDb.WebsiteOrders
                              where (m.Website.Webmaster.Username == userlogin && m.MoneyStatus == 1)
                              select m;
            var url = from web in StoreDb.Websites
                      where web.Webmaster.Username == userlogin
                      select web;



            ReportDetailsViewModels model = new ReportDetailsViewModels() { list = orderReport.ToList(),listUrl=url.ToList()};
      
            return View(model);
        }

        public ActionResult viewdetails(string id)
        {
            string[]temp = id.Split(new char[]{'_'},StringSplitOptions.None);

            int date = int.Parse(temp[0]);
            int websiteId = int.Parse(temp[1]);

            
            StringBuilder sb = new StringBuilder();
            
            string userlogin = User.Identity.Name;
                        var orderReport = from m in StoreDb.WebsiteOrders
                                  where (m.Website.Webmaster.Username == userlogin && m.MoneyStatus == 1 && m.WebsiteId == websiteId)
                                  select m;

            sb.AppendFormat("<tr><th>1</th><th>2</th> <th>3</th> </tr>");

           
            if (date == 1)
            {// all times
               
                if (websiteId == -1)// all url
                {
                    var order = from o in StoreDb.WebsiteOrders
                              where (o.Website.Webmaster.Username == userlogin && o.MoneyStatus == 1)
                              select o;
                    foreach (var temps in order)
                    {
                        sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", temps.BuyingId, temps.Date, temps.Amount);

                    }
                    Response.Write(sb.ToString());
                    return null;
                }
                else // url cu the nao do
                {
                     var order = from o in StoreDb.WebsiteOrders
                              where (o.Website.Webmaster.Username == userlogin && o.MoneyStatus == 1 && o.WebsiteId == websiteId)
                            select o;
                     foreach (var temps in order)
                    {
                        sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", temps.BuyingId, temps.Date, temps.Amount);

                    }
                    Response.Write(sb.ToString());
                    return null;
                }


            }
            else if (date == -1 || date == 0)// yesterday or today
            {
                DateTime checkdata = DateTime.Now.AddDays(date).Date;

                if (websiteId == -1)// yesterday or today cua all url
                {
                    var order = from m in StoreDb.WebsiteOrders
                                where (m.Website.Webmaster.Username == userlogin && m.MoneyStatus == 1)
                                select m;

                    foreach (var key in order)
                    {
                        if (key.Date.Date == checkdata)
                        {
                            sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", key.BuyingId, key.Date, key.Amount);
                        }
                    }
                    Response.Write(sb.ToString());
                    return null;

                }
                else//yesterday or today cua 1 url nao do
                {
                    foreach (var key in orderReport)
                    {
                        if (key.Date.Date == checkdata)
                        {
                            sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", key.BuyingId, key.Date, key.Amount);
                        }
                    }
                    Response.Write(sb.ToString());
                    return null;
                }
                
            }
            else if (date == -7 || date == -30 || date == -90)// truong hop last
            {
                DateTime checkdata = DateTime.Now.AddDays(date).Date;
                DateTime dateNow = DateTime.Now.Date;

                if (websiteId == -1) // last cua all URL
                {
                    var order = from m in StoreDb.WebsiteOrders
                                where (m.Website.Webmaster.Username == userlogin && m.MoneyStatus == 1)
                                select m;

                    foreach (var key in order.Where(o => o.Date >= checkdata && o.Date <= dateNow))
                    {
                        sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", key.BuyingId, key.Date, key.Amount);
                    }
                    Response.Write(sb.ToString());
                    return null;
                }
                else // last cua 1 url nao do
                {
                    foreach (var key in orderReport.Where(o => o.Date >= checkdata && o.Date <= dateNow))
                    {
                        sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", key.BuyingId, key.Date, key.Amount);
                    }
                    Response.Write(sb.ToString());
                    return null;
                }

            }
            return View();
         
            
           

           

        }



    }
}
