using System.Data.Entity;

namespace GuestBookApp.Models
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.GuestEntries.Add(new GuestEntry
            {
                Name = "Администратор",
                Message = "Добро пожаловать в нашу книгу отзывов! Оцените нашу работу.",
                Rating = 5,
                Date = System.DateTime.Now
            });

            context.SaveChanges();
        }
    }
}