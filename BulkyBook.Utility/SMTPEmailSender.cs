using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Utility
{
    public class SMTPEmailSender
    {
        public void SendEmail(string username, string subject, string body)
        {
            var smtpClient = new SmtpClient(SD.SMTPHost)
            {
                Port = 587,
                Credentials = new NetworkCredential(SD.SMTPUserName, SD.SMTPPassword),
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(SD.SMTPMailAddress),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(username);
            smtpClient.Send(mailMessage);
        }
    }
}
