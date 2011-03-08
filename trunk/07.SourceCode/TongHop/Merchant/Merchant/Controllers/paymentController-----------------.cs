using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Merchant.Models;
using System.Configuration;

namespace Merchant.Controllers
{
    public class paymentController : Controller
    {
        MainClient main = new MainClient();

        public MPWebmasterEntities StoreDb = new MPWebmasterEntities(); 
        [HttpPost]
        public ActionResult MPSecureValue(FormCollection form)
        {
           
            string hashbutton = "";
            bool submitButton = false;
            foreach (var key in form.AllKeys)
            {
                if (key == "hosted_button_id")
                {
                    hashbutton = form[key];
                    submitButton = true;

                }

            }
            if (submitButton)
            {

                var checkit = from s in StoreDb.Scripts
                              where (s.HashValue == hashbutton)
                              select s;
                

                if (checkit.Count() == 1) // nut hop le
                {
                    int virtualproduct = (int)checkit.First().Virtual;
               

                    ViewData["hashbutton"] = hashbutton;
                    ViewData["type"] = "F";// form nhap pacific code
                    ViewData["virutal"] = virtualproduct.ToString(); //Is virtual product or not
                  

                    return View();
                }
                else
                    return View("payerror");
            }
            else // Nhan Form nhap ma Pacific code
            {
                // bien danh cho truong hop nhap ma
                int i = 0;
                string hash="";
                string email = "";
                int virtualproduct = 1;


                //bien danh cho truong hop nhap thong tin address
                string name = "", ReceiverAddress = "", phone = "", Hanhashbutton = "", emailaddress = "", codelists = "";
                int checkit=1;



                List<string> listCode = new List<string>();

                foreach (var key in form.AllKeys) {
                    i++;
                    /* nhan form trong truong hop nhap ma */
                    if (key == ("code_" + i))
                        listCode.Add(form[key]);

                    else if (key == "hash")
                        hash = form[key];
                    else if (key == "email")
                        email = form[key];
                    else if (key == "virtualProduct")
                        virtualproduct = int.Parse(form[key]);


                        // nhap form trong truong hop nhap thong tin address

                    else if (key == "name")
                        name = form[key];
                    else if (key == "ReceiverAddress")
                        ReceiverAddress = form[key];
                    else if (key == "phone")
                        phone = form[key];
                    else if (key == "Hanhashbutton")
                        Hanhashbutton = form[key];
                    else if (key == "emailaddress")
                        emailaddress = form[key];
                    else if (key == "codelist")
                        codelists = form[key];
                    else if (key == "checkit")
                        checkit = int.Parse(form[key]);


                }
                if (virtualproduct == 0 && checkit != 0)
                {
                    string codelist = "";
                    foreach (var code in listCode)
                        codelist += code.ToString() + "*";
                    ViewData["hash"] = hash;
                    ViewData["email"] = email;
                    ViewData["type"] = "A"; // form nhap address
                    ViewData["codelist"] = codelist;
                    return View();
                }
                else if (checkit == 0)//nhan form address thanh cong
                {
                    try
                    {
                        var Script = StoreDb.Scripts.Single(s => s.HashValue == Hanhashbutton);

                        MoneyPacificSrv.DTO.PaymentModel pay = new MoneyPacificSrv.DTO.PaymentModel();

                        int price = (int)Script.Price;
                        string[] l = codelists.Split(new char[]{'*'},StringSplitOptions.None);
                        List<string> lcode = new List<string>();
                        for (int jj = 0; jj < l.Length; jj++)
                            if (l[jj] != "")
                                lcode.Add(l[jj]);
                        
                        pay = main.MakePayment(lcode.ToArray(), price);
                        
                        bool success = pay.Success;
                        if (success)
                        {
                           string buyid = "";
                           bool flag=false;
                           //save data to BuyCustomer

                           BuyCustomer b = new BuyCustomer();
                           do
	                        {
                                buyid = MPHash.Hash10("test").Substring(0, 15).ToUpper();
                                 flag = StoreDb.BuyCustomers.Where(m => m.BuyingId == buyid).Any();
                                 if (!flag)
                                 {
                                     b.BuyingId = buyid;
                                     b.Password = buyid;
                                     bool checkUserRoleExist = StoreDb.UserInRoles.Where(e => e.Username == buyid).Any();
                                     if (!checkUserRoleExist)
                                     {
                                         MyRoleProvider role = new MyRoleProvider();
                                         string[] nameuser = new string[] { buyid };
                                         string[] namerole = new string[] { "ProblemUser" };
                                         role.AddUsersToRoles(nameuser, namerole);
                                     }


                                 }
                               
	         
	                        } while (flag);
                            
                            b.DeliveryAddress = ReceiverAddress;
                            b.Email = emailaddress;
                            b.BuyingId = buyid;

                            StoreDb.BuyCustomers.AddObject(b);
                            //end save data to BuyCustomer
                            StoreDb.SaveChanges();

                            // string mess = pay.Message;
                            ViewData["type"] = "S";//thanh cong
                            ViewData["returnURL"] = Script.URLSuccess;

                            //luu qua bang Websiteorder
                            WebsiteOrder w = new WebsiteOrder();
                            w.Name = Script.ScriptName;
                            w.Status = 411;// new order
                            w.WebsiteId = Script.WebsiteId;
                            w.Date = DateTime.Now;
                            w.Amount = price;
                            w.BuyingId = buyid;
                            w.MoneyStatus = 0;// 0 is pending processing
                            w.ProductType = 0;// la real product

                            StoreDb.WebsiteOrders.AddObject(w);
                            StoreDb.SaveChanges();


                            //send mail to customer

                            if (emailaddress != "")
                            {
                                string customerMailConent = "Hello!<br/><br/>";
                                customerMailConent += "You've just buy the product with Money Pacific Payment.<br/><br/>";
                                customerMailConent += "Your buying code is <b>" + buyid + "</b><br/><br/>";
                                customerMailConent += "To follow your order, you can use Username:<b>"+buyid+"</b> and Password:<b>"+buyid+"</b> to login on Money Pacific Website System.<br/><br/>";
                                customerMailConent += "See you on http://wwww.money-pacific.com.";
                                try
                                {
                                    MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], emailaddress, "", "", "You've bought with Money Pacific", customerMailConent);
                                }
                                catch(Exception)
                                {

                                }
                            }

                            //end send email to customer



                            //send email to webmaster
                            string loginid = User.Identity.Name;
                            var webmaster = StoreDb.Webmasters.Single(ww => ww.Username == loginid);

                            string webmasterMailContent = "Hello!";
                            webmasterMailContent += "You have new order with money pacific payment!<br/><br/>";
                            webmasterMailContent += "See you on http://www.money-pacific.com.";

                            if (!string.IsNullOrEmpty(webmaster.NotificationNewOrder))
                            {
                                try
                                {
                                    MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], webmaster.NotificationNewOrder, "", "", "You've new order!", webmasterMailContent);
                                }
                                catch (Exception)
                                { }
                            }
                            else
                                MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], webmaster.Email, "", "", "You've new order!", webmasterMailContent);


                            return View();
                        }
                        else
                            return View("payerror", new { id = pay.Message });
                    }
                    catch (Exception e)
                    {
                        return View("payerror", new { id = e.Message });

                    }


                }
                else if (checkit == 1)// truong hop la virtual product
                {
                    try 
                    {
                        var Script = StoreDb.Scripts.Single(s => s.HashValue == hash);

                        MoneyPacificSrv.DTO.PaymentModel pay = new MoneyPacificSrv.DTO.PaymentModel();

                        int price = (int)Script.Price;
                        

                      
                        pay = main.MakePayment(listCode.ToArray(), price);
                        
                        bool success = pay.Success;

                        if (success)//ok
                        {
                            string buyid = "";
                            bool flag = false;
                            //save data to BuyCustomer

                            BuyCustomer b = new BuyCustomer();
                            do
                            {
                                buyid = MPHash.Hash10("test").Substring(0, 15).ToUpper();
                                flag = StoreDb.BuyCustomers.Where(m => m.BuyingId == buyid).Any();
                                if (!flag)
                                {
                                    b.BuyingId = buyid;
                                    b.Password = buyid;

                                    bool checkUserRoleExist = StoreDb.UserInRoles.Where(e => e.Username == buyid).Any();
                                    if (!checkUserRoleExist)
                                    {
                                        MyRoleProvider role = new MyRoleProvider();
                                        string[] nameuser = new string[] { buyid };
                                        string[] namerole = new string[] { "ProblemUser" };
                                        role.AddUsersToRoles(nameuser, namerole);
                                    }
                                }


                            } while (flag);

                            b.DeliveryAddress = "";
                            b.Email = email;
                            b.BuyingId = buyid;

                            StoreDb.BuyCustomers.AddObject(b);
                            //end save data to BuyCustomer
                            StoreDb.SaveChanges();

                            //luu qua bang Websiteorder
                            WebsiteOrder w = new WebsiteOrder();
                            w.Name = Script.ScriptName;
                            w.Status = 411;// new order
                            w.WebsiteId = Script.WebsiteId;
                            w.Date = DateTime.Now;
                            w.Amount = price;
                            w.BuyingId = buyid;
                            w.MoneyStatus = 0;// 0 is pending processing
                            w.ProductType = 1; // 1 la virtual product

                            StoreDb.WebsiteOrders.AddObject(w);
                            StoreDb.SaveChanges();
                            // string mess = pay.Message;
                            ViewData["type"] = "S";//thanh cong
                            ViewData["returnURL"] = Script.URLSuccess;


                            //send mail to customer

                            if (email != "")
                            {
                                string customerMailConent = "Hello!<br/><br/>";
                                customerMailConent += "You've just buy the product with Money Pacific Payment.<br/><br/>";
                                customerMailConent += "Your buying code is <b>" + buyid + "</b><br/><br/>";
                                customerMailConent += "To follow your order, you can use Username:<b>" + buyid + "</b> and Password:<b>" + buyid + "</b> to login on Money Pacific Website System.<br/><br/>";
                                customerMailConent += "See you on http://wwww.money-pacific.com.";
                                MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], email, "", "", "You've bought with Money Pacific", customerMailConent);

                            }

                            //end send email to customer



                            //send email to webmaster
                            string loginid = User.Identity.Name;
                            var webmaster = StoreDb.Webmasters.Single(ww => ww.Username == loginid);


                            if (webmaster.Email != "")
                            {
                                string webmasterMailContent = "Hello!";
                                webmasterMailContent += "You have new order with money pacific payment!<br/><br/>";
                                webmasterMailContent += "See you on http://www.money-pacific.com.";
                                MPMail.SendMail(ConfigurationManager.AppSettings["MailSender"], webmaster.Email, "", "", "You've new order!", webmasterMailContent);
                            }








                            return View();
                        }
                        else
                            return View("payerror", new { id = pay.Message });
 
                    }
                    catch(Exception e)
                    { 

                    }

                    return View();
 
                }


                return View();
                    
            }
            
        }
        public ActionResult payerror(string id)
        {
            ViewData["message"] = id;
            return View();
        }
        
    }
}
