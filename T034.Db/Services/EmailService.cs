using System;
using System.Net;
using System.Net.Mail;
using Db.Services.Common;

namespace Db.Services
{
    public interface IEmailService : IService
    {
        void SendEmail(string subject, string body);
    }

    public class EmailService : IEmailService
    {
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

            var message = new MailMessage(from, to, subject, body);

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                            ex.ToString());
            }
        }
    }
}
