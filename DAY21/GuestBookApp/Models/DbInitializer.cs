using System.Data.Entity;

namespace GuestBookApp.Models
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            Feedback feedback = new Feedback();
            feedback.UserName = "Администратор";
            feedback.Message = "Добро пожаловать в нашу книгу отзывов!";
            feedback.Rating = 5;
            feedback.SubmittedAt = System.DateTime.Now;

            context.Feedbacks.Add(feedback);
            context.SaveChanges();
        }
    }
}