using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;

namespace Merchant.Models
{
    public class MPMail
    {
        public static void SendMail(string from, string to, string cc, string bcc, string subject, string content)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(from, "Money Pacific");
            msg.To.Add(to);
            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.BodyEncoding = new System.Text.UTF8Encoding();
            msg.Body = content;
            msg.Priority = MailPriority.High;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            System.Net.NetworkCredential user = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["MailSender"], ConfigurationManager.AppSettings["MailSenderPass"]);
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


        internal void SendMail(string p, MPMail mail, string p_2, string p_3, string p_4, string mailContent)
        {
            throw new NotImplementedException();
        }
    }
}