using System;
using System.Net;
using System.Net.Mail;
using Db.Services.Common;
using NLog;
    
namespace Db.Services
{
    public interface IEmailService : IService
    {
        void SendEmail(string subject, string body);
    }

    public class EmailService : IEmailService
    {
        protected readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly EmailConfig _emailConfig;
        public EmailService(EmailConfig emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public void SendEmail(string subject, string body)
        {
            var to = _emailConfig.To;
            var from = _emailConfig.From;

            var client = new SmtpClient(_emailConfig.Server);
            client.Port = 465;
            client.Credentials = new NetworkCredential(_emailConfig.UserName, _emailConfig.Password);
            client.EnableSsl = true;

            var message = new MailMessage(from, to, subject, body);



            try
            {
                var smtpClient = new SmtpClient();
                var msg = new MailMessage();
                msg.To.Add(_emailConfig.To);
                msg.Subject = subject;
                msg.Body = body;
                smtpClient.EnableSsl = false;
                smtpClient.Send(msg);

                //client.Send(message);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                Console.WriteLine("Exception caught in SendEmail(): {0}", ex);
            }
        }
    }
}
