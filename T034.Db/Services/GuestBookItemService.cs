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
        private readonly IEmailService _emailService;
        public GuestBookItemService(IEmailService emailService)
        {
            _emailService = emailService;
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
                Date = DateTime.Now,
                IsShow = false,
                Message = sendMessageDto.Message               
            };
            var result = Db.SaveOrUpdate(entity);

            _emailService.SendEmail("Новая запись", sendMessageDto.Message);

            return Mapper.Map<GuestBookItemDto>(entity);
        }


    }
}
