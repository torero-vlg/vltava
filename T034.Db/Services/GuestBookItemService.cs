using System;
using System.Collections.Generic;
using System.Linq;
using Db.Dto;
using Db.Entity;
using Db.Services.Common;
using System.Net.Mail;
using System.Net;

namespace Db.Services
{
    public interface IGuestBookItemService : IService
    {
        IEnumerable<GuestBookItemDto> Select();
        OperationResult Delete(object itemId);
        GuestBookItemDto Create(GuestBookItemDto dto);
        GuestBookItemDto Update(GuestBookItemDto dto);
        GuestBookItemDto Get(object id);
        GuestBookItemDto SendMessage(SendMessageDto sendMessageDto);
    }



    public class GuestBookItemService : AbstractRepository<GuestBookItem, GuestBookItemDto, int>, IGuestBookItemService
    {
        private readonly EmailConfig _emailConfig;
        public GuestBookItemService(EmailConfig emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public new OperationResult Delete(object itemId)
        {
            if (Db.Where<GuestBookItem>(m => m.Parent.Id == (int)itemId).Any())
                return new OperationResult { Status = StatusOperation.Error, Message = "Существует запись, у которой удаляемая является родителем" };

            var item = Db.Get<GuestBookItem>(itemId);
            var result = Db.Delete(item);
            return new OperationResult { Status = StatusOperation.Success };
        }

        public GuestBookItemDto SendMessage(SendMessageDto sendMessageDto)
        {
            var entity = new GuestBookItem
            {
                Author = sendMessageDto.Author,
                Contact = sendMessageDto.Contact,
                Date = sendMessageDto.Date,
                IsShow = false,
                Message = sendMessageDto.Message               
            };
            var result = Db.SaveOrUpdate(entity);


            return Mapper.Map<GuestBookItemDto>(entity);
        }

        private void SendEmail(string server)
        {
            string to = _emailConfig.To;
            string from = _emailConfig.From;
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Using the new SMTP client.";
            message.Body = @"Using this new feature, you can send an e-mail message from an application very easily.";
            SmtpClient client = new SmtpClient(server);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_emailConfig.UserName, _emailConfig.Password);

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
