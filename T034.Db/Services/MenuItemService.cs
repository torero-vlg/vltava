using System.Collections.Generic;
using System.Linq;
using Db.Dto;
using Db.Entity;
using Db.Services.Common;

namespace Db.Services
{
    public interface IMenuItemService : IService
    {
        IEnumerable<MenuItemDto> Select();
        MenuItemDto ByUrl(string url);
        OperationResult Delete(object menuItemId);
    }

    public class MenuItemService : AbstractRepository<MenuItem, MenuItemDto, int>, IMenuItemService
    {
        public MenuItemDto ByUrl(string url)
        {
            var item = Db.Where<MenuItem>(i => i.Url == url).FirstOrDefault();
            var dto = Mapper.Map<MenuItemDto>(item);
            return dto;
        }

        public new OperationResult Delete(object menuItemId)
        {
            if (Db.Where<MenuItem>(m => m.Parent.Id == (int)menuItemId).Any())
                return new OperationResult { Status = StatusOperation.Error, Message = "Существует пункт меню, у которого удаляемый является родителем" };

            var item = Db.Get<MenuItem>(menuItemId);
            var result = Db.Delete(item);
            return new OperationResult { Status = StatusOperation.Success };
        }
    }
}
