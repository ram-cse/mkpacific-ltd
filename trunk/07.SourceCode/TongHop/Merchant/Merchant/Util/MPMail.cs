using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;

namespace MoneyPacificSite.Util
{
    public class Mail
    {
        public string Subject { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }

        public Mail()
        {
            Subject = "";
            To = "";
            From = "";
            Body = "";
        }
    }

    public class MPMail
    {
        public static void SendForEmail(Mail mail)
        {
            mail.To = ConfigurationManager.AppSettings["MP_Mail"];
        }

        public static void Send(Mail mail)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(mail.From, "Money Pacific Service");
            msg.To.Add(new MailAddress(mail.To));
            msg.Subject = mail.Subject;
            msg.Body = mail.Body;

            msg.IsBodyHtml = true;
            msg.BodyEncoding = new System.Text.UTF8Encoding();
            msg.Priority = MailPriority.High;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            System.Net.NetworkCredential user = new
                System.Net.NetworkCredential(
                    ConfigurationManager.AppSettings["sender"],
                    ConfigurationManager.AppSettings["senderPass"]
                    );

            smtp.EnableSsl = true;
            smtp.Credentials = user;
            smtp.Port = 587; //or use 465 
            object userState = msg;

            try
            {
                //you can also call client.Send(msg)
                smtp.SendAsync(msg, userState);
            }
            catch (SmtpException)
            {
                //Catch errors...
            }
        }
    }
}