using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merchant.Models;
using System.Text;
using Merchant.Helper;
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
            try
            {
                //get list website of current user
                var website = from temp in StoreDb.Websites
                              where (temp.Webmaster.Username == User.Identity.Name)
                              select temp;
                List<WebsiteOrder> listorder =  new List<WebsiteOrder>();
                List<WebsiteOrder> listorderMoneyAvailable = new List<WebsiteOrder>();

                foreach (var w in website)
                {
                    //get all orders of specific website
                    var order = from o in StoreDb.WebsiteOrders
                                where o.Website.Id == w.Id
                                select o;

                    foreach (var or in order)
                    {
                        listorder.Add(or);// add all order vào list
                    }


                }//end foreach
                /////////////////////////////////////////////////////////////////////////////

                int totalEarning = 0; // amount of all orders
                int pending = 0; // amount of order that has Status 411(new order) and 412( order on delivery)
                int problem = 0;
                int MoneyAvailable = 0; //money available

                foreach (var order in listorder)
                {
                    totalEarning += order.Amount; // total money of all order

                    if ((order.Status == 411 || order.Status == 412) && order.MoneyStatus == 0 ) // pending...
                    {
                        pending += order.Amount;
 
                    }

                    if ((order.Status == 421 || order.Status == 422 || order.Status == 423) && order.MoneyStatus == 0) // problem orders
                    {
                        problem += order.Amount;
 
                    }

                    if (order.MoneyStatus == 1)
                    {
                        MoneyAvailable += order.Amount;
                        
 
                    }

                    listorderMoneyAvailable.Add(order); //list money available


                    ViewData["totalEarning"] = totalEarning.ToString("n0");
                    ViewData["pending"] = pending.ToString("n0");
                    ViewData["problem"] = problem.ToString("n0");
                    ViewData["MoneyAvailable"] = MoneyAvailable.ToString("n0");

                }


                var widthdraw = StoreDb.Parameters.Single(o => o.Name == "MinWithDraw");
                ViewData["limitedWidthDraw"] = int.Parse(widthdraw.Value).ToString("n0");


                ////////////end 



                DateTime today = DateTime.Now.Date;
                DateTime FirtDateofMonth = HtmlHelpers.GetFirstDayOfMonth(DateTime.Today);
                DateTime LastDateofMonth = HtmlHelpers.GetTheLastDayOfMonth(DateTime.Today);
                DateTime FirstDateofLastMonth = HtmlHelpers.GetFirstDayOfMonth(today.AddMonths(-1));
                DateTime LastDateofLastMonth = HtmlHelpers.GetTheLastDayOfMonth(today.AddMonths(-1));

                DateTime FirstDateofYear = new DateTime(today.Year, 1, 1);
                DateTime LastDateofYear = new DateTime(today.Year, 12, 31);

                int todayearning = 0, yesterdayearning = 0, thismonthearning = 0, lastmonthearning = 0, thisyearearning = 0;

                foreach (var order in listorderMoneyAvailable)
                {
                    if (order.Date == today)
                    {
                        todayearning += order.Amount;
                    }

                    if (order.Date == today.AddDays(-1))
                    {
                        yesterdayearning += order.Amount;
                    }
                    if (order.Date >= FirtDateofMonth && order.Date <= LastDateofMonth)
                    {
                        thismonthearning += order.Amount;

                    }
                    if (order.Date >= FirstDateofLastMonth && order.Date <= LastDateofLastMonth)
                    {
                        lastmonthearning += order.Amount;
                    }
                    if (order.Date >= FirstDateofYear && order.Date <= LastDateofYear)
                    {
                        thisyearearning += order.Amount;
                    }




                }
                ViewData["todayearning"] = todayearning.ToString("n0");
                ViewData["yesterdayearning"] = yesterdayearning.ToString("n0");
                ViewData["thismonthearning"] = thismonthearning.ToString("n0");
                ViewData["lastmonthearning"] = lastmonthearning.ToString("n0");
                ViewData["thisyearearning"] = thisyearearning.ToString("n0");









            }
            catch (Exception e)
            {
                return View("RequireSetPayment");
 
            }
            return View();
        }
        
        public ActionResult setWithdraw()
        {
            string userlogin = User.Identity.Name;
            Earning earning = StoreDb.Earnings.Single(m => m.Webmaster.Username == userlogin);
            var getValue = StoreDb.Parameters.Single(p => p.Name == "MinWithDraw");
            int values = int.Parse(getValue.Value.ToString());

            if (earning.Amount >= values)
            {
                earning.Status = 1;
                earning.DateWithDraw = DateTime.Now;
            }
            StoreDb.SaveChanges();
            TransactionLogViewModel.AddLog(userlogin + " has just set withdraw successfully!", DateTime.Now);
            
            return RedirectToAction("moneyview");

        }
        
        public ActionResult details()
        {
            string userlogin = User.Identity.Name;

            var orderReport = from m in StoreDb.WebsiteOrders
                              where (m.Website.Webmaster.Username == userlogin && m.MoneyStatus == 1)
                              select m;

            int total = 0;
            foreach (var x in orderReport)
            {
                total += x.Amount;

            }
            var url = from web in StoreDb.Websites
                      where web.Webmaster.Username == userlogin
                      select web;


            TransactionLogViewModel.AddLog(userlogin + " has just viewed the Report Details!", DateTime.Now);

            ReportDetailsViewModels model = new ReportDetailsViewModels() { list = orderReport.ToList(),listUrl=url.ToList()};
      
            ViewData["total"] = total.ToString("n0");
            return View(model);
        }

        public ActionResult viewdetails(string id)
        {
            string[]temp = id.Split(new char[]{'_'},StringSplitOptions.None);

            int date = int.Parse(temp[0]);
            int websiteId = int.Parse(temp[1]);

            LangText.Load(User.Identity.Name);
            

            StringBuilder sb = new StringBuilder();
            
            string userlogin = User.Identity.Name;
                        var orderReport = from m in StoreDb.WebsiteOrders
                                  where (m.Website.Webmaster.Username == userlogin && m.MoneyStatus == 1 && m.WebsiteId == websiteId)
                                  select m;

            sb.AppendFormat("<tr><th>{0}</th><th>{1}</th> <th>{2}</th> </tr>", LangText.GetText("BUYINGID"), LangText.GetText("DATE"),LangText.GetText("AMOUNT"));

           
            if (date == 1)
            {// all times
               
                if (websiteId == -1)// all url
                {
                    var order = from o in StoreDb.WebsiteOrders
                              where (o.Website.Webmaster.Username == userlogin && o.MoneyStatus == 1)
                              select o;
                    int total=0;
                    foreach (var temps in order)
                    {
                        sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", temps.BuyingId, temps.Date, temps.Amount);
                        total += temps.Amount;
                            
                    }
                    sb.AppendFormat("<tr><td colspan=\"3\"></td></tr>");
                    sb.AppendFormat("<tr><td></td><td></td><td><strong>{0}: {1} VND </strong></td></tr>",LangText.GetText("TOTAL"),total.ToString("n0"));
                    Response.Write(sb.ToString());
                    return null;
                }
                else // url cu the nao do
                {
                     var order = from o in StoreDb.WebsiteOrders
                              where (o.Website.Webmaster.Username == userlogin && o.MoneyStatus == 1 && o.WebsiteId == websiteId)
                            select o;
                     int total = 0;
                     foreach (var temps in order)
                    {
                        sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", temps.BuyingId, temps.Date, temps.Amount);
                        total += temps.Amount;

                    }
                     sb.AppendFormat("<tr><td colspan=\"3\"></td></tr>");
                     sb.AppendFormat("<tr><td></td><td></td><td><strong>{0}: {1} VND </strong></td></tr>", LangText.GetText("TOTAL"), total.ToString("n0"));

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
                    int total = 0;
                    foreach (var key in order)
                    {
                        if (key.Date.Date == checkdata)
                        {
                            sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", key.BuyingId, key.Date, key.Amount);
                            total += key.Amount;
                        }
                    }
                    sb.AppendFormat("<tr><td colspan=\"3\"></td></tr>");
                    sb.AppendFormat("<tr><td></td><td></td><td><strong>{0}: {1} VND </strong></td></tr>", LangText.GetText("TOTAL"), total.ToString("n0"));
                    Response.Write(sb.ToString());
                    return null;

                }
                else//yesterday or today cua 1 url nao do
                {
                    int total = 0;
                    foreach (var key in orderReport)
                    {
                        if (key.Date.Date == checkdata)
                        {
                            sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", key.BuyingId, key.Date, key.Amount);
                            total += key.Amount;
                        }
                    }
                    sb.AppendFormat("<tr><td colspan=\"3\"></td></tr>");
                    sb.AppendFormat("<tr><td></td><td></td><td><strong>{0}: {1} VND </strong></td></tr>", LangText.GetText("TOTAL"), total.ToString("n0"));
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
                    int total = 0;
                    foreach (var key in order.Where(o => o.Date >= checkdata && o.Date <= dateNow))
                    {
                        sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", key.BuyingId, key.Date, key.Amount);
                        total += key.Amount;
                    }
                    sb.AppendFormat("<tr><td colspan=\"3\"></td></tr>");
                    sb.AppendFormat("<tr><td></td><td></td><td><strong>{0}: {1} VND </strong></td></tr>", LangText.GetText("TOTAL"), total.ToString("n0"));
                    Response.Write(sb.ToString());
                    return null;
                }
                else // last cua 1 url nao do
                {
                    int total = 0;
                    foreach (var key in orderReport.Where(o => o.Date >= checkdata && o.Date <= dateNow))
                    {
                        sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", key.BuyingId, key.Date, key.Amount);
                        total += key.Amount;
                    }
                    sb.AppendFormat("<tr><td colspan=\"3\"></td></tr>");
                    sb.AppendFormat("<tr><td></td><td></td><td><strong>{0}: {1} VND </strong></td></tr>", LangText.GetText("TOTAL"), total.ToString("n0"));
                    Response.Write(sb.ToString());
                    return null;
                }

            }
            return View();
         
            
           

           

        }



    }
}
