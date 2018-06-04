using System.Collections.Generic;
using System.Linq;
using Db.Dto;
using Db.Entity;
using Db.Services.Common;

namespace Db.Services
{
    public interface IGuestBookItemService : IService
    {
        IEnumerable<GuestBookItemDto> Select();
        OperationResult Delete(object itemId);
        GuestBookItemDto Create(GuestBookItemDto dto);
        GuestBookItemDto Update(GuestBookItemDto dto);
    }

    public class GuestBookItemService : AbstractRepository<GuestBookItem, GuestBookItemDto, int>, IGuestBookItemService
    {
        public new OperationResult Delete(object itemId)
        {
            if (Db.Where<GuestBookItem>(m => m.Parent.Id == (int)itemId).Any())
                return new OperationResult { Status = StatusOperation.Error, Message = "Существует запись, у которой удаляемая является родителем" };

            var item = Db.Get<GuestBookItem>(itemId);
            var result = Db.Delete(item);
            return new OperationResult { Status = StatusOperation.Success };
        }
    }
}
