using Domain;
using Microsoft.EntityFrameworkCore;
using Route = Domain.Route;

public class BusContext : Microsoft.EntityFrameworkCore.DbContext
{
    private readonly IConfiguration _configuration;
    public BusContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public DbSet<Bus> Buses { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Entry> Entries { get; set; }
    public DbSet<Loop> Loops { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Stop> Stops { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("SqlLite");
        optionsBuilder.UseSqlite(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bus>().HasKey(b => b.Id);
        modelBuilder.Entity<Driver>().HasKey(d => d.Id);
        modelBuilder.Entity<Entry>().HasKey(e => e.Id);
        modelBuilder.Entity<Loop>().HasKey(l => l.Id);
        modelBuilder.Entity<Route>().HasKey(r => r.Id);
        modelBuilder.Entity<Stop>().HasKey(s => s.Id);
    }
}