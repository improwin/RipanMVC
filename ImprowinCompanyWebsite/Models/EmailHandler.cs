using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;


namespace ImprowinCompanyWebsite.Models
{
    public class EmailHandler
    {
        public string _subject { get; set; }
        public string _sender { get; set; }
        public string _displayName { get; set; }
        public string[] _recipients { get; set; }
        public StringBuilder _mailbody { get; set; }

        public EmailHandler(string subject, string sender, string displayName, string[] recipients, StringBuilder mailbody)
        {
            _subject = subject;
            _sender = sender;
            _recipients = recipients;
            _mailbody = mailbody;
            _displayName = displayName;
        }

        public EmailHandler() { }

        public bool Send()
        {
            MailMessage _objMsg = new MailMessage();
            foreach (string tmp in _recipients)
            {
                _objMsg.To.Add(tmp);
            }

            _objMsg.From = new MailAddress(_sender, _displayName);
            _objMsg.Subject = _subject;
            _objMsg.IsBodyHtml = true;
            _objMsg.Body = _mailbody.ToString();

            SmtpClient _smtpClient = new SmtpClient("improwinsolutions.com", 587);
            _smtpClient.EnableSsl = false;
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.Credentials = new System.Net.NetworkCredential("info@improwinsolutions.com", "Fightforwin#2015");

            try
            {
                _smtpClient.Send(_objMsg);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}