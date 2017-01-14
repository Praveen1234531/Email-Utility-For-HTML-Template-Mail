using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace emailUtility
{
    public static class Smtpinfo {

        public static string Smtp { get; set; }
        public static int SmtpPort { get; set; }
        public static string SenderEmailId { get; set; }
        public static string Password { get; set; }
        public static string ReplyTo { get; set; }

        public static void initialize() {
            Smtp = ConfigurationManager.AppSettings["smptHost"];
            ReplyTo = ConfigurationManager.AppSettings["replyTo"];
            SmtpPort =Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            SenderEmailId = ConfigurationManager.AppSettings["senderEmailId"];
            Password = ConfigurationManager.AppSettings["password"];
        }
    }
    public class Mailer
    {
        public static bool SmtpMailer(string senderAddress, string senderName, string recipientAddress, string recipientName, string subject, string body, ref string status, string mailCC = null)
        {            
           var message = new MailMessage()
            {
                From = new MailAddress(senderAddress, senderName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true                
            };
            message.ReplyToList.Add(Smtpinfo.ReplyTo);
            if (!string.IsNullOrEmpty(mailCC))
                message.CC.Add(mailCC);

            recipientAddress.Split(',').ToList().ForEach(x =>
            {
                message.To.Add(new MailAddress(x, x));
            });

            try
            {
                var client = new SmtpClient
                {
                    Host = Smtpinfo.Smtp,
                    Port = Smtpinfo.SmtpPort,
                    EnableSsl = true,
                    Timeout = 10000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Smtpinfo.SenderEmailId, Smtpinfo.Password)
                };               
                client.Send(message);
                status = "Successfully Send";
            }
            catch (Exception ex)
            {
                status = ex.Message;
                return false;
            }
            return true;
        }
    }
}
