using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;

namespace P3_MoneyPacificSite.Utilator
{
    public class MKMail
    {
        public void SendMail(string from, string to, string cc, 
            string bcc, string subject, string content)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(from, "Japan Extreme");
            msg.To.Add(to);
            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.BodyEncoding = new System.Text.UTF8Encoding();
            msg.Body = content;
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