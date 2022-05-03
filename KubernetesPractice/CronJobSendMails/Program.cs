using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;

namespace CronJobSendMails
{
    internal class Program
    {
        public static string Secret = "9gyQgfrWDgrtCbRjIUTvdFEdgsSGTWUSrNWW1gWvwPQYHd";
        public static int RefreshTokenTTL = 2;
        public static string EmailFrom = "info@vijay.com";
        public static string SmtpHost = "smtp-relay.sendinblue.com";
        public static int SmtpPort = 587;
        public static string SmtpUser = "vijaychamp@msn.com";
        public static string SmtpPass = "k3IZDferDWXqE9P7xsw34F2Qv8A";

        static void Main(string[] args)
        {
            SendEmail();
        }

        private static void SendEmail()
        {
            string RandomId= Guid.NewGuid().ToString();
            Send(
                to: SmtpUser,
                subject: "Mail from Kubernetes Cluster",
                html: $@"<h4>Hey..!! This Email is fom Kubernetes Cron Job: Cluster time: {DateTime.Now} ans Random Id: {RandomId} </h4>"
            );
        }
        private static void Send(string to, string subject, string html, string from = null)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? EmailFrom));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect(SmtpHost, SmtpPort, SecureSocketOptions.StartTls);
            smtp.Authenticate(SmtpUser, SmtpPass);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
