using System;

namespace Db.Entity
{
    /// <summary>
    /// Запись гоствой книги
    /// </summary>
    public class GuestBookItem : Entity
    {
        /// <summary>
        /// Автор
        /// </summary>
        public virtual string Author { get; set; }

        /// <summary>
        /// Контакт
        /// </summary>
        public virtual string Contact { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public virtual DateTime Date { get; set; }

        /// <summary>
        /// Запись на которую дан ответ
        /// </summary>
        public virtual GuestBookItem Parent { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public virtual string Message { get; set; }

        /// <summary>
        /// Отображать или нет
        /// </summary>
        public virtual bool IsShow { get; set; }

        public override string ToString()
        {
            return Message;
        }
    }
}
