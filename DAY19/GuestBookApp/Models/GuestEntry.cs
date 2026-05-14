using System;
using System.ComponentModel.DataAnnotations;

namespace GuestBookApp.Models
{
    public class GuestEntry
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите ваше имя")]
        [Display(Name = "Имя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 50 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите сообщение")]
        [Display(Name = "Сообщение")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Сообщение должно быть от 1 до 500 символов")]
        public string Message { get; set; }

        [Display(Name = "Дата")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}