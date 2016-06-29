using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
   public static  class Temparary
    {
        public static string sendMail(string toemail, string from, string subject, string body, bool isBodyHTml)
        {
            System.Net.Mail.MailMessage objMsg = new System.Net.Mail.MailMessage();
            objMsg.To.Add(toemail);
            objMsg.Subject = subject;
            objMsg.Body = body;
            objMsg.IsBodyHtml = isBodyHTml;
            objMsg.Priority = System.Net.Mail.MailPriority.Normal;
            objMsg.From = new System.Net.Mail.MailAddress(from);

            System.Net.Mail.SmtpClient SMTPServer = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["mailServer"]);
            SMTPServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
            SMTPServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPUser"], ConfigurationManager.AppSettings["Pwd"]);
            try
            {
                SMTPServer.Send(objMsg);
                return "1";
            }
            catch (Exception ex)
            {
                string str = "0";
                return str.ToString();
            }

        }
    }
}
