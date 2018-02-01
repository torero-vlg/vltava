using System.ComponentModel.DataAnnotations;

namespace Db.Dto.Common
{
    public class IdNameDto<T> : AbstractDto<T>
    {
        [Display(Name = "Наименование")]
        public string Name { get; set; }
    }
}
