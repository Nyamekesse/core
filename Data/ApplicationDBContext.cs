using Microsoft.EntityFrameworkCore;



public class ApplicationDBContext: DbContext
{

    string dbHost = Environment.GetEnvironmentVariable("DB_HOST")!;
    string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD")!;
    string dbName = Environment.GetEnvironmentVariable("DB_NAME")!;
    string dbUserName = Environment.GetEnvironmentVariable("DB_USERNAME")!;
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        string connectionString = $"Host={dbHost};Database={dbName};Username={dbUserName};Password={dbPassword}";
        optionsBuilder.UseNpgsql(connectionString);
    }
    
}