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

        public static EmailUtilty()
        {
            //reading Email Configuration

        }
        public static void SendEmail(string toAddress, string fromAddress, string subject, string message, bool IsHtmlMessage)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(toAddress));
            msg.From = new MailAddress(fromAddress);
            msg.Subject = subject;
            msg.Body = message;
            msg.IsBodyHtml = IsHtmlMessage;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com",465);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials=new NetworkCredential()
            smtpClient.Send(msg);



        }
    }
}
