using System;

namespace Db.Dto
{
    /// <summary>
    /// Входящее сообщение для гостевой книги
    /// </summary>
    public class SendMessageDto
    {
        /// <summary>
        /// Автор
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Контакт
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message { get; set; }
    }
}
