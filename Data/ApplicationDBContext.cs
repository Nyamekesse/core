using Microsoft.EntityFrameworkCore;

public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : DbContext(options)
{

    public DbSet<Book> Books { get; set; }

    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>().Property(p=>p.Price).HasPrecision(10,5);
    }
}