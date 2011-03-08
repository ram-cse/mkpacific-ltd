using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merchant.Models;
using System.Configuration;
namespace Merchant.Controllers
{
    [Authorize]
    public class WebsiteController : Controller
    {

        public MPWebmasterEntities StoreDb = new MPWebmasterEntities();
        public ActionResult Index()
        {
            return View();
        }


        [MPAccess(Roles = "Webmaster")]
        public ActionResult Add()
        {
            string idlogin = User.Identity.Name;
            var Idmaster = StoreDb.Webmasters.Single(m => m.Username == idlogin);

            var weblist = from m in StoreDb.Websites
                          where (m.WebmasterId == Idmaster.Id && m.Status==1)
                          select m;
            WebsiteViewModel model = new WebsiteViewModel() {list=weblist.ToList() };
            TransactionLogViewModel.AddLog("Webmaster: "+idlogin + " has just gone to the add website area!", DateTime.Now);

            var phonenumber = StoreDb.Parameters.Single(s => s.Name == "PhoneNumber").Value;
            ViewData["phone"] = phonenumber.ToString();

            return View(model);
        } 

        [HttpPost]
        [MPAccess(Roles = "Webmaster")]
        public ActionResult Add(FormCollection collection)
        {
                        
            {
                string idlogin = User.Identity.Name;
                var Idmaster = StoreDb.Webmasters.Single(m=>m.Username == idlogin);
                Website w = new Website();
                w.DateJoin = DateTime.Now;
                w.WebmasterId = Idmaster.Id;

                foreach (var key in collection.AllKeys)
                {
                    if (key == "Title")
                        w.Title = collection[key];
                    else if(key=="URL")
                        w.URL = collection[key];
                    else if(key == "Description")
                        w.Description = collection[key];

                }
                w.Status = 0;//chua duoc validate

                StoreDb.Websites.AddObject(w);
                StoreDb.SaveChanges();
                TransactionLogViewModel.AddLog("Webmaster: " + idlogin + " has just added the website: "+w.URL+" successfully!", DateTime.Now);
                return RedirectToAction("AddDone");
            }
           
        }
        public ActionResult AddDone()
        {
            return View();
        }

        
        //
        // GET: /Website/Edit/5
        [MPAccess(Roles = "Webmaster")]
        public ActionResult Edit(int id)
        {
            var website = StoreDb.Websites.Single(n => n.Id == id);
            TransactionLogViewModel.AddLog("Webmaster: " + User.Identity.Name + " has just requested to edit the website!", DateTime.Now);
            return View(website);
        }

        //
        // POST: /Website/Edit/5

        [HttpPost]
        [MPAccess(Roles = "Webmaster")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var web = StoreDb.Websites.Single(m=>m.Id == id);
                foreach (var key in collection.AllKeys)
                {
                    if (key == "Title")
                        web.Title = collection[key];
                    if(key == "URL")
                        web.URL = collection[key]; ;
                    if(key == "Description")
                        web.Description = collection[key];

                }
                StoreDb.SaveChanges();
                TransactionLogViewModel.AddLog("Webmaster: " + User.Identity.Name + " has just edited the website: "+web.URL+" successfully!", DateTime.Now);
                return RedirectToAction("Add");
            }
            catch
            {
                return View();
            }
        }

        [MPAccess(Roles = "Webmaster")]
        public ActionResult script(int? id)
        {
            if (id.HasValue)// neu co rui thi sua
            {
                var script = StoreDb.Scripts.Single(m => m.Id == id);
                ViewData["key"] = "1";
                TransactionLogViewModel.AddLog("Webmaster: " + User.Identity.Name + " has just requested to edit the Script!", DateTime.Now);
                return View(script);
            }
            TransactionLogViewModel.AddLog("Webmaster: " + User.Identity.Name + " has just requested to get the Script!", DateTime.Now);
            ViewData["key"] = "0";
            var phonenumber = StoreDb.Parameters.Single(s => s.Name == "PhoneNumber").Value;
            ViewData["phone"] = phonenumber.ToString();
            
            return View();
 
        }
        [HttpPost]
        [MPAccess(Roles = "Webmaster")]
        public ActionResult script(FormCollection form)
        {
            string type = "";
            foreach (var key in form.AllKeys)
            {
                if (key == "Type")
                {
                    type = form[key];
                }
 
            }

            if(type == "0")
            {//chua co thi them
                    string userlogin = User.Identity.Name;
                    var websiteList = from m in StoreDb.Websites
                                      where (m.Webmaster.Username == userlogin)
                                      select m;

                    Script s = new Script();

           

                    s.DateGet = DateTime.Now;
         
                    int virtualproduct=0;
                   

                    foreach (var key in form.AllKeys)
                    {
                        if (key == "website")
                        {

                            s.WebsiteId = int.Parse(form[key]);

                        }
                        else  if (key == "scriptName")
                        {
                            s.ScriptName = form[key];
                        }
                        //else   if (key == "ItemName")
                        //{
                        //    s.ItemName = form[key];
                        //}
                        //else if (key == "ItemId")
                        //{
                        //    s.ItemId = form[key];
                        //}
                        else if (key == "Price")
                        {
                            s.Price = int.Parse(form[key]);
                        }
                        else  if (key == "Currency")
                        {
                            s.Currency = form[key];
 
                        }
                        else  if (key == "buttonStyle")
                        {
                            s.ButtonStyle = int.Parse( form[key]);
                        }
                        else if (key == "urlsuccess")
                        {
                            s.URLSuccess = form[key];
                        }
                        else if (key == "urlfail")
                        {
                            s.URLFail = form[key];
                        }
                         else if (key == "virtual")
                        {
                            virtualproduct = 1;
                        }                       
                      
                    }

                s.Virtual = virtualproduct;// 1: virtual products
               

                string hash = MPHash.hash(DateTime.Now.ToString()+ s.ScriptName);
                s.HashValue = hash;
                
                string image = "";
                if (s.ButtonStyle == 1)
                {
                    image = ConfigurationManager.AppSettings["ImageBt1"];
                }
                else if (s.ButtonStyle == 2)
                {
                    image = ConfigurationManager.AppSettings["ImageBt2"];
                }

                string code = "<form action="+ConfigurationManager.AppSettings["formAction"]+" method=\"post\">";

                code += "<input type=\"hidden\" name=\"hosted_button_id\" value=\"" + hash + "\"/> ";
                code += "<input type=\"image\" src=\"" + image + "\" border=\"0\" name=\"submit\" alt=\"Buy Online - Pay by Cash\" />";
                code += "</form>";
                  
                
                
                s.Code = code;

                StoreDb.Scripts.AddObject(s);
                StoreDb.SaveChanges();

                int getid = StoreDb.Scripts.Single(ss=>ss.HashValue == hash).Id;

                TransactionLogViewModel.AddLog("Webmaster: " + User.Identity.Name + " has just got the Script: "+s.ScriptName +" successfully!", DateTime.Now);

                return RedirectToAction("getScript", new { id = getid });
            }
            else// co rui thi sua
            {
                int scriptId=0;
                foreach (var key in form.AllKeys)
                {
                    if (key == "scriptId")
                        scriptId = int.Parse(form[key]);
                }

                var s = StoreDb.Scripts.Single(m=>m.Id == scriptId);

                int virtualproduct = 0;
             

                foreach (var key in form.AllKeys)
                {
                    if (key == "website1")
                    {

                        s.WebsiteId = int.Parse(form[key]);

                    }
                    else if (key == "scriptName1")
                    {
                        s.ScriptName = form[key];
                    }
                    //else if (key == "ItemName1")
                    //{
                    //    s.ItemName = form[key];
                    //}
                    //else if (key == "ItemId1")
                    //{
                    //    s.ItemId = form[key];
                    //}
                    else if (key == "Price1")
                    {
                        s.Price = int.Parse(form[key]);
                    }
                    else if (key == "Currency1")
                    {
                        s.Currency = form[key];

                    }
                    else if (key == "buttonStyle1")
                    {
                        s.ButtonStyle = int.Parse(form[key]);
                    }
                    else if (key == "urlsuccess1")
                    {
                        s.URLSuccess = form[key];
                    }
                    else if (key == "urlfail1")
                    {
                        s.URLFail = form[key];
                    }
                    
                    else if (key == "virtual1")
                    {
                        virtualproduct = 1;
                    }
                   

                }

                s.Virtual = virtualproduct;

                StoreDb.SaveChanges();

                TransactionLogViewModel.AddLog("Webmaster: " + User.Identity.Name + " has just update the Script: "+s.ScriptName+" successfully!", DateTime.Now);
                return RedirectToAction("getScript", new { id = scriptId });
            }
 
        }
        [MPAccess(Roles = "Webmaster")]
        public ActionResult getScript(int id)
        {
            var script = StoreDb.Scripts.Single(m=>m.Id == id);
            ViewData["scriptId"] = id.ToString();
            return View(script);
        }


        [MPAccess(Roles = "Webmaster")]
        public ActionResult scriptmanager()
        {
            string loginUser = User.Identity.Name;
            var webmaster = StoreDb.Webmasters.Single(m=>m.Username == loginUser);

            var website = from w in StoreDb.Websites
                          where (w.WebmasterId == webmaster.Id)
                          select w;
            List<Script> listscript = new List<Script>();
            foreach (var ws in website)
            {
                var scritpt = from s in StoreDb.Scripts
                              where s.WebsiteId == ws.Id
                              orderby s.DateGet descending
                              select s;
                foreach (var sc in scritpt)
                    listscript.Add(sc);
            }

            var phonenumber = StoreDb.Parameters.Single(s => s.Name == "PhoneNumber").Value;
            ViewData["phone"] = phonenumber.ToString();
            ScriptViewModel model = new ScriptViewModel() { list = listscript };
            TransactionLogViewModel.AddLog("Webmaster: " + User.Identity.Name + " has just gone to the Script Manager!", DateTime.Now);
            return View(model);
        }

        [MPAccess(Roles = "Webmaster")]
        public ActionResult deletescript(int id)
        {
            var Script = StoreDb.Scripts.Single(m=>m.Id == id);
            StoreDb.Scripts.DeleteObject(Script);
            StoreDb.SaveChanges();
            TransactionLogViewModel.AddLog("Webmaster: " + User.Identity.Name + " has just deleted the Script: "+Script.ScriptName+" successfully!", DateTime.Now);
            return RedirectToAction("scriptmanager");
        }

        
        public ActionResult Delete(int id)
        {
            //xoa website thi xoa het tat ca bang tham chieu toi website nay
            
            var website = StoreDb.Websites.Single(m=>m.Id == id);
            StoreDb.Websites.DeleteObject(website);
            StoreDb.SaveChanges();

            return RedirectToAction("Add");
        }
    }
}
