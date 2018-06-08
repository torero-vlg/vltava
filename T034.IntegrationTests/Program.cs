using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db.Services;
using Db.Services.Common;

namespace T034.IntegrationTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailConfig = new EmailConfig
            {
                Server = "robots.1gb.ru",
                From = "test@t034.ru",
                To = "test@t034.ru",
                UserName = "u474469",
                Password = "Qwerty1"
            };
            var emailService = new EmailService(emailConfig);

            emailService.SendEmail("123", "QWERTYY");
        }
    }
}
