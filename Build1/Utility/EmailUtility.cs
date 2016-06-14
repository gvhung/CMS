using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Configuration;
namespace Utility
{
    public static class EmailUtilty
    {
        static string SmtpHost, SmtpUser, SmtpPassword, SmtpPort, BCC;
        static bool IsSSL;
        static EmailUtilty()
        {
            //reading Email Configuration
            SmtpHost = ConfigurationManager.AppSettings["SMTPHOST"].ToString();
            SmtpPort = ConfigurationManager.AppSettings["SMTPPORT"].ToString();
            SmtpUser = ConfigurationManager.AppSettings["SMTPUSER"].ToString();
            SmtpPassword = ConfigurationManager.AppSettings["SMTPPWD"].ToString();
            BCC = ConfigurationManager.AppSettings["ADMINEMAILID"].ToString();
            IsSSL =Convert.ToBoolean( ConfigurationManager.AppSettings["SSL"]);

        }
        public static void SendEmail(string toAddress, string fromAddress, string subject, string message, bool IsHtmlMessage)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(toAddress));
            msg.From = new MailAddress(fromAddress);
            msg.Subject = subject;
            msg.Body = message;
            msg.Bcc.Add(new MailAddress(BCC));
            msg.IsBodyHtml = IsHtmlMessage;

            SmtpClient smtpClient = new SmtpClient(SmtpHost,Convert.ToInt32( SmtpPort));
            smtpClient.EnableSsl = IsSSL;
            smtpClient.Credentials = new NetworkCredential(SmtpUser,SmtpPassword);
            smtpClient.Send(msg);



        }
    }
}
