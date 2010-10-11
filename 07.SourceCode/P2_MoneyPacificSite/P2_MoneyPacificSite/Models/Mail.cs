using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P2_MoneyPacificSite.Models
{
    public class Mail
    {
        private string m_from;
        private string m_to;
        private string m_subject;
        private string m_body;

        public string From
        {
            get { return m_from; }
            set { m_from = value; }
        }

        public string To
        {
            get { return m_to; }
            set { m_to = value; }
        }

        public string Subject
        {
            get { return m_subject; }
            set { m_subject = value; }
        }

        public string Body
        {
            get { return m_body; }
            set { m_body = value; }
        }        

        //msg.From = new MailAddress(from, "Japan Extreme");
        //msg.To.Add(to);
        //msg.Subject = subject;
        //msg.IsBodyHtml = true;
        //msg.BodyEncoding = new System.Text.UTF8Encoding();
        //msg.Body = content;
        //msg.Priority = MailPriority.High;

    }
}