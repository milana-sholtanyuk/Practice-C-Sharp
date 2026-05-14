using System.Data.Entity;

namespace GuestBookApp.Models
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // Добавляем тестовые данные
            context.GuestEntries.Add(new GuestEntry
            {
                Name = "Администратор",
                Message = "Добро пожаловать в нашу книгу отзывов! Оставьте свой отзыв.",
                Date = System.DateTime.Now
            });

            context.SaveChanges();
        }
    }
}