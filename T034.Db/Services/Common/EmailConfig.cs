namespace Db.Services.Common
{
    public class EmailConfig
    {
        /// <summary>
        /// Адресат
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Отправитель
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
    }
}
