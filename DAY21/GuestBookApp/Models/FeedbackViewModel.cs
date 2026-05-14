using System.ComponentModel.DataAnnotations;

namespace GuestBookApp.Models
{
    public class FeedbackViewModel
    {
        [Required(ErrorMessage = "Введите ваше имя")]
        [Display(Name = "Имя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 50 символов")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите текст отзыва")]
        [Display(Name = "Отзыв")]
        [StringLength(500, ErrorMessage = "Отзыв не должен превышать 500 символов")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Укажите рейтинг")]
        [Range(1, 5, ErrorMessage = "Рейтинг должен быть от 1 до 5")]
        [Display(Name = "Рейтинг")]
        public int Rating { get; set; }
    }
}