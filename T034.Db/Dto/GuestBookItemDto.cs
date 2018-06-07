using System;
using Db.Dto.Common;

namespace Db.Dto
{
    /// <summary>
    /// Запись гостевой книги
    /// </summary>
    public class GuestBookItemDto : AbstractDto<int>
    {
        /// <summary>
        /// Автор
        /// </summary>
        public  string Author { get; set; }

        /// <summary>
        /// Контакт
        /// </summary>
        public  string Contact { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public  DateTime Date { get; set; }

        /// <summary>
        /// Запись на которую дан ответ
        /// </summary>
        public int? ParentId { get; set; }

        public string Parent { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public  string Message { get; set; }

        /// <summary>
        /// Отображать или нет
        /// </summary>
        public bool IsShow { get; set; }

        public override string ToString()
        {
            return Message;
        }
    }
}