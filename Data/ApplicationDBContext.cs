using System.Reflection.Emit;
using ef_core;
using ef_core.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
    : DbContext(options)
{
    public DbSet<Book> Books { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Publisher> Publishers { get; set; }

    public DbSet<SubCategory> SubCategories { get; set; }

    public DbSet<BookDetail> BookDetails { get; set; }

    public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }

    // rename to Fluent_BookDetail
    public DbSet<Fluent_BookDetail> BookDetail_fluent { get; set; }

    public DbSet<Fluent_Book> Fluent_Books { get; set; }
    public DbSet<Fluent_Author> Fluent_Authors { get; set; }
    public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }
    public DbSet<Fluent_BookAuthorMap> Fluent_BookAuthorMaps { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Fluent_BookDetail
        modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());

        // Fluent_Book
        modelBuilder.ApplyConfiguration(new FluentBookConfig());

        // Fluent_Publisher
        modelBuilder.ApplyConfiguration(new FluentPublisherConfig());

        // Fluent_Author
        modelBuilder.ApplyConfiguration(new FluentAuthorConfig());

        // Fluent_BookAuthorMap
        modelBuilder.ApplyConfiguration(new FluentBookAuthorMap());

        modelBuilder.Entity<Book>().Property(p => p.Price).HasPrecision(10, 5);
        modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });

        modelBuilder
            .Entity<Book>()
            .HasData(
                new Book
                {
                    Id = 1,
                    ISBN = "1234567890",
                    Price = 9.99m,
                    Title = "The Great Gatsby",
                    Publisher_Id = 1
                },
                new Book
                {
                    Id = 2,
                    ISBN = "9876543210",
                    Price = 29.99m,
                    Title = "To Kill a Mockingbird",
                    Publisher_Id = 3
                },
                new Book
                {
                    Id = 3,
                    ISBN = "5432109876",
                    Price = 19.99m,
                    Title = "Pride and Prejudice",
                    Publisher_Id = 2
                },
                new Book
                {
                    Id = 4,
                    ISBN = "4567890123",
                    Price = 25.99m,
                    Title = "The Catcher in the Rye",
                    Publisher_Id = 1
                },
                new Book
                {
                    Id = 5,
                    ISBN = "3210987654",
                    Price = 14.99m,
                    Title = "1984",
                    Publisher_Id = 1
                },
                new Book
                {
                    Id = 6,
                    ISBN = "2109876543",
                    Price = 19.99m,
                    Title = "The Lord of the Rings",
                    Publisher_Id = 1
                }
            );

        modelBuilder
            .Entity<Publisher>()
            .HasData(
                new Publisher
                {
                    Publisher_Id = 1,
                    Name = "John Doe",
                    Location = "New York"
                },
                new Publisher
                {
                    Publisher_Id = 2,
                    Name = "Jane Doe",
                    Location = "Los Angeles"
                },
                new Publisher
                {
                    Publisher_Id = 3,
                    Name = "Bob Smith",
                    Location = "Miami Beach"
                }
            );

        modelBuilder
            .Entity<Category>()
            .HasData(
                new Category { Id = 1, CategoryName = "Fiction" },
                new Category { Id = 2, CategoryName = "Non-fiction" },
                new Category { Id = 3, CategoryName = "Novels" }
            );
    }
}
