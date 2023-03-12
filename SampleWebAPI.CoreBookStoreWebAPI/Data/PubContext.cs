using System;
using SampleWebAPI.CoreBookStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SampleWebAPI.CoreBookStoreWebAPI.Data
{
	public class PubContext : DbContext
	{
        public PubContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
      new Author { AuthorId = 1, FirstName = "Erick", LastName = "Kurniawan" });

            var authorList = new Author[]{
                new Author {AuthorId = 3, FirstName = "Budi", LastName = "Ozeki" },
                new Author {AuthorId = 4, FirstName = "Sofia", LastName = "Segovia" },
                new Author {AuthorId = 5, FirstName = "Ursula K.", LastName = "LeGuin" },
                new Author {AuthorId = 6, FirstName = "Hugh", LastName = "Howey" },
                new Author {AuthorId = 7, FirstName = "Isabelle", LastName = "Allende" }
            };
            modelBuilder.Entity<Author>().HasData(authorList);

            var someBooks = new Book[]{
                new Book {BookId = 1, AuthorId=1, Title = "In God's Ear",
                    PublishDate= new DateTime(1989,3,1) },
                new Book {BookId = 2, AuthorId=2, Title = "A Tale For the Time Being",
                PublishDate = new DateTime(2013,12,31) },
                new Book {BookId = 3, AuthorId=3, Title = "The Left Hand of Darkness",
                PublishDate=(DateTime)new DateTime(1969,3,1)} };
            modelBuilder.Entity<Book>().HasData(someBooks);
        }
    }
}

