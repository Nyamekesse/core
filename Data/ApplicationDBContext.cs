using Microsoft.EntityFrameworkCore;

public class ApplicationDBContext: DbContext
{

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>().Property(p=>p.Price).HasPrecision(10,5);
    }
    
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }
}