using Microsoft.EntityFrameworkCore;

public class BusContext : DbContext
{
    public DbSet<Bus> Buses { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Entry> Entries { get; set; }
    public DbSet<Loop> Loops { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Stop> Stops { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure your database connection here
        optionsBuilder.UseSqlServer("Your_Connection_String");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the entity models and their relationships here
        modelBuilder.Entity<Bus>().HasKey(b => b.Id);
        modelBuilder.Entity<Driver>().HasKey(d => d.Id);
        modelBuilder.Entity<Entry>().HasKey(e => e.Id);
        modelBuilder.Entity<Loop>().HasKey(l => l.Id);
        modelBuilder.Entity<Route>().HasKey(r => r.Id);
        modelBuilder.Entity<Stop>().HasKey(s => s.Id);
    }
}