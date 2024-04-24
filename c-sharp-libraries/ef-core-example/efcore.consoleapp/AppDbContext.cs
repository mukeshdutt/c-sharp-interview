using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    private const string connectionString = "server=localhost;user=root;database=adventureworks;password=@Pass810";

    public DbSet<Vendor> Vendor { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(connectionString);
    }
}