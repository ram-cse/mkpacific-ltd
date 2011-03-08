using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Merchant.Models;
using System.IO;

namespace Merchant.Controllers
{
    [MPAccess(Roles = "Webmaster, Admin")]
    public class MessengerController : Controller
    {
        MPWebmasterEntities db = new MPWebmasterEntities();
        // GET: /Messenger/
        [MPAccess(Roles="Webmaster, Admin")]
        public ActionResult Index()
        {
            string userlogin = User.Identity.Name;
            var order = from o in db.WebsiteOrders
                        where o.Website.Webmaster.Username == userlogin
                        select o;
            
                List<Message> msgList = new List<Message>();
                foreach (var or in order)
                {
                    try
                    {
                        //var list = (from l in db.Messages
                        //            where l.UserId == or.BuyingId
                        //            orderby l.DateSend descending
                        //            select l).First();
                        var list  = from l in db.Messages
                                    where l.UserId == or.BuyingId
                                    select l;
                        if (list.Any())
                        {
                            foreach (var temp in list)
                            {
                                msgList.Add(temp);
                            }

                        }
                        
                        

                    }
                    catch (Exception)
                    {
 
                    }

                }

                var chat = from c in db.ChatBoxes
                           where c.Webmaster.Username == userlogin
                           orderby c.DateSend descending
                           select c;
                
                MessengerIndexViewModel model = new MessengerIndexViewModel() { MessageList = msgList,chatbox = chat.ToList() };
                TransactionLogViewModel.AddLog(userlogin+" has just gone to the Pacific Messenger!", DateTime.Now);

                return View(model);
         }

        [MPAccess(Roles="Webmaster, MPAdmin")]
        public ActionResult create(int?id)
        {
            string userlogin = User.Identity.Name;
            if (!id.HasValue)
            {
               
                var chat = from c in db.ChatBoxes
                           where c.Webmaster.Username == userlogin
                           orderby c.DateSend descending
                           select c;

                CreateMessageViewModel model = new CreateMessageViewModel() { ListChat = chat.ToList() };
                TransactionLogViewModel.AddLog(userlogin + " has just created the message on Pacific Messenger!", DateTime.Now);
                return View(model);
            }
            else if (id.HasValue)
            {
                var chat = from c in db.ChatBoxes
                           where c.WebmasterId == id
                           orderby c.DateSend descending
                           select c;
                CreateMessageViewModel model = new CreateMessageViewModel() { ListChat = chat.ToList() };
                TransactionLogViewModel.AddLog(userlogin + " has just viewed the message on Pacific Messenger!", DateTime.Now);
                return View(model);
 
            }
            return null;
        }

        [MPAccess(Roles = "Webmaster, MPAdmin")]
        [HttpPost]
        public ActionResult create(string message)
        {
            string userlogin = User.Identity.Name;
            var checkit = db.Webmasters.Where(w => w.Username == userlogin);
            
            if (message != "")
            {
                ChatBox p = new ChatBox();
                HttpPostedFileBase _file = Request.Files["file"];
                if (_file.FileName != "")
                {
                    if (_file.ContentLength > 0)
                    {
                        string filename = _file.FileName.Replace(" ", "_");
                        string filePath = Path.Combine(HttpContext.Server.MapPath("/Content/File/"), Path.GetFileName(filename));

                        _file.SaveAs(filePath);

                        p.AttachFile = "/Content/File/" + _file.FileName.Replace(" ", "_");

                    }

                }
                p.Message = message;
                p.DateSend = DateTime.Now;
                if (checkit.Any())
                {
                    p.Sender = 0;//0: webmaster, 1: money pacific admin
                }
                else p.Sender = 1;
                p.WebmasterId = checkit.First().Id;

                db.ChatBoxes.AddObject(p);
                db.SaveChanges();

                TransactionLogViewModel.AddLog(userlogin + " has just created the message on Pacific Messenger!", DateTime.Now);
            }


            return RedirectToAction("Create");
        }

        [MPAccess(Roles="Admin")]
        public ActionResult sendWebmaster()// send message to  webmaster
        {
            var webmaster = from w in db.Webmasters
                            select w;

            return View(webmaster.ToList());
        }

        [MPAccess(Roles = "Admin")]
        [HttpPost]
        public ActionResult sendWebmaster(string message, string[] selectWebmaster)// send message to  webmaster
        {
            if (!string.IsNullOrEmpty(message))
            {
                HttpPostedFileBase file = Request.Files["file"];

                string fileAttach = "";
                string listWebmaster="";
                if (file.FileName != "")
                {
                    if (file.ContentLength > 0)// co attach file
                    {
                        string filename = file.FileName.Replace(' ', '_');
                        string filePath = Path.Combine(HttpContext.Server.MapPath("/Content/File/"), Path.GetFileName(filename));

                        file.SaveAs(filePath);

                        fileAttach = "/Content/File/" + file.FileName.Replace(" ", "_");

                    }
                }
                if (int.Parse(selectWebmaster[0]) != 0)
                {  //send to 1 nguoi
                    ChatBox msg = new ChatBox();
                    msg.AttachFile = fileAttach;
                    msg.DateSend = DateTime.Now;
                    msg.Message = message;
                    msg.Sender = 1;//0: webmaster, 1: money pacific admin
                    msg.WebmasterId = int.Parse(selectWebmaster[0]);

                    Webmaster w = db.Webmasters.Single(ww=>ww.Id == msg.Id);
                    listWebmaster+=w.Username+" ";
                    db.ChatBoxes.AddObject(msg);
                    


                }
                else // send to all webmaster
                {
                    var webmaster = from web in db.Webmasters
                                    select web;
                    foreach (var x in webmaster)
                    {
                        ChatBox msg = new ChatBox();
                        msg.AttachFile = fileAttach;
                        msg.DateSend = DateTime.Now;
                        msg.Message = message;
                        msg.Sender = 1;//0: webmaster, 1: money pacific admin
                        msg.WebmasterId = x.Id;
                        Webmaster w = db.Webmasters.Single(ww=>ww.Id == msg.Id);
                        listWebmaster+=w.Username+" ";

                        db.ChatBoxes.AddObject(msg);
                    }

                }
                TransactionLogViewModel.AddLog("Money Pacific Admin has just sent the message on Pacific Messenger to: "+listWebmaster, DateTime.Now);
                db.SaveChanges();
            }
            return View("SendDone");
        }


        public string test()
        {
            return MPHash.Hash10("test").Substring(0,15).ToUpper();
        }

    }


    
}
