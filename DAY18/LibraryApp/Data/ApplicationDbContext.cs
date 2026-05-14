using LibraryApp.Models;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace LibraryApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=LibraryDbConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        public DbSet<BookModel> Books { get; set; }
        public DbSet<LoanModel> Loans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookModel>().HasKey(b => b.Id);
            modelBuilder.Entity<BookModel>().Property(b => b.Title).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<BookModel>().Property(b => b.Author).HasMaxLength(100);
            modelBuilder.Entity<BookModel>().Property(b => b.Genre).HasMaxLength(100);

            modelBuilder.Entity<LoanModel>().HasKey(l => l.Id);
            modelBuilder.Entity<LoanModel>().Property(l => l.ReaderName).IsRequired().HasMaxLength(100);
        }
    }
}