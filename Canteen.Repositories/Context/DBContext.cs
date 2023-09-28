using Canteen.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Canteen.Repositories.Context;

public class DBContext : DbContext
{
    public DbSet<Food_Footprint> Food_Footprint { get; set; }
    public DbSet<Food_Menu> Food_Menu { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // TODO SQL CONNECTION STRING!
        var cnString = "server=10.131.15.57;user=program;password=SuperSecretPassword1337;database=DOOM";
        // var cnString = "server=10.131.15.57;user=program;password=SuperSecretPassword1337;database=doom";
        var serverVersion = new MySqlServerVersion(new Version(10,9,0));
        optionsBuilder.UseMySql(cnString, serverVersion)
            .LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Food_Menu>()
            .HasOne(f => f.FoodFootprint)
            .WithMany(ff => ff.FoodMenu)
            .HasForeignKey(k => k.FootprintID);

        modelBuilder.Entity<Food_Footprint>()
            .HasKey(f => f.FootprintID);
    }   
}
