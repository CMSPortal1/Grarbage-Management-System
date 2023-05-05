using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Common.SendingEmail
{
   public class GMailer
    {
        public static string SenderMail { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }

        static GMailer()
        {
            GmailHost = "smtp.gmail.com";
            GmailPort = 587;
            GmailSSL = true;
        }

        public void Send()
        {
            SmtpClient smtpServer = new SmtpClient();
            smtpServer.Host = GmailHost;
            smtpServer.Port = GmailPort;
            smtpServer.EnableSsl = GmailSSL;
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Credentials = new NetworkCredential(SenderMail, GmailPassword);

            using (var message = new MailMessage(SenderMail, ToEmail))
            {
                message.Subject = Subject;
                message.Body = Body;
                message.IsBodyHtml = IsHtml;
                smtpServer.Send(message);
            }


        }
    }
}
