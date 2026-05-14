using System;
using System.ComponentModel.DataAnnotations;

namespace GuestBookApp.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите ваше имя")]
        [Display(Name = "Имя пользователя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 50 символов")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите сообщение")]
        [Display(Name = "Сообщение")]
        [StringLength(500, ErrorMessage = "Сообщение не должно превышать 500 символов")]
        public string Message { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Рейтинг должен быть от 1 до 5")]
        [Display(Name = "Рейтинг")]
        public int Rating { get; set; }

        [Display(Name = "Дата создания")]
        [DataType(DataType.DateTime)]
        public DateTime SubmittedAt { get; set; }
    }
}