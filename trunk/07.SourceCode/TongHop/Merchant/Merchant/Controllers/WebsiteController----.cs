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

             

        public ActionResult Add()
        {
            string idlogin = User.Identity.Name;
            var Idmaster = StoreDb.Webmasters.Single(m => m.Username == idlogin);

            var weblist = from m in StoreDb.Websites
                          where (m.WebmasterId == Idmaster.Id)
                          select m;
            WebsiteViewModel model = new WebsiteViewModel() {list=weblist.ToList() };

            return View(model);
        } 

        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {

            //try
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
                    if(key=="URL")
                        w.URL = collection[key];
                    if(key == "Description")
                        w.Description = collection[key];

                }

                StoreDb.Websites.AddObject(w);
                StoreDb.SaveChanges();

                return RedirectToAction("Add");
            }
           
        }
        
        //
        // GET: /Website/Edit/5
 
        public ActionResult Edit(int id)
        {
            var website = StoreDb.Websites.Single(n => n.Id == id);

            return View(website);
        }

        //
        // POST: /Website/Edit/5

        [HttpPost]
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
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult script(int? id)
        {
            if (id.HasValue)
            {
                var script = StoreDb.Scripts.Single(m => m.Id == id);
                ViewData["key"] = "1";
                return View(script);
            }
            ViewData["key"] = "0";
            return View();
 
        }
        [HttpPost]
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



            if(type == "0"){//chua co thi them
                    string userlogin = User.Identity.Name;
                    var websiteList = from m in StoreDb.Websites
                                      where (m.Webmaster.Username == userlogin)
                                      select m;

                    Script s = new Script();

           

                    s.DateGet = DateTime.Now;
         
                    int virtualproduct=0;
                    int address = 0;

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
                        else   if (key == "ItemName")
                        {
                            s.ItemName = form[key];
                        }
                        else if (key == "ItemId")
                        {
                            s.ItemId = form[key];
                        }
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

                s.Virtual = virtualproduct;
              

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
                int address = 0;

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
                    else if (key == "ItemName1")
                    {
                        s.ItemName = form[key];
                    }
                    else if (key == "ItemId1")
                    {
                        s.ItemId = form[key];
                    }
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


                return RedirectToAction("getScript", new { id = scriptId });
            }
 
        }
        public ActionResult getScript(int id)
        {
            var script = StoreDb.Scripts.Single(m=>m.Id == id);
            ViewData["scriptId"] = id.ToString();
            return View(script);
        }



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
                              select s;
                foreach (var sc in scritpt)
                    listscript.Add(sc);
            }
            ScriptViewModel model = new ScriptViewModel() { list = listscript };
            return View(model);
        }





        public ActionResult deletescript(int id)
        {
            var Script = StoreDb.Scripts.Single(m=>m.Id == id);
            StoreDb.Scripts.DeleteObject(Script);
            StoreDb.SaveChanges();
            return RedirectToAction("scriptmanager");
        }

        //
        // POST: /Website/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
