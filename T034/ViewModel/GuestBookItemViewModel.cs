using System;
using System.ComponentModel.DataAnnotations;

namespace T034.ViewModel
{
    public class GuestBookItemViewModel
    {
        [Display(Name = "Код")]
        public int Id { get; set; }

        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Display(Name = "Контакт")]
        public string Contact { get; set; }

        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Display(Name = "Сообщение")]
        public string Message { get; set; }

        [Display(Name = "Показать")]
        public bool IsShow { get; set; }
    }
}