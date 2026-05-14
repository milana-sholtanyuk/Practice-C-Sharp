using System.Data.Entity;

namespace GuestBookApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=GuestBookDB")
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}