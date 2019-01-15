using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("AppDataBase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>()
            //            .HasOne<Author>(a => a.Author)
            //            .WithMany(b => b.Books)
            //            .HasForeignKey(a => a.Id);

            //modelBuilder.Entity<Book>().HasData(new Book() { Id = 1, Author = new Author() { Id = 1 }, NumPages = 150, Title = "Book 1" });
            //modelBuilder.Entity<Book>().HasData(new Book() { Id = 2, Author = new Author() { Id = 1 }, NumPages = 950, Title = "Book 2" });
            //modelBuilder.Entity<Book>().HasData(new Book() { Id = 3, Author = new Author() { Id = 2 }, NumPages = 150, Title = "Book 3" });
            //modelBuilder.Entity<Book>().HasData(new Book() { Id = 4, Author = new Author() { Id = 3 }, NumPages = 180, Title = "Book 4" });

            //modelBuilder.Entity<Author>().HasData(new Author() { Id = 1, Name = "Author 1" });
            //modelBuilder.Entity<Author>().HasData(new Author() { Id = 2, Name = "Author 2" });
            //modelBuilder.Entity<Author>().HasData(new Author() { Id = 3, Name = "Author 3" });

        }
    }

}
