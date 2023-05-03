using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Route = Domain.Route;
using Domain;

public class BusContext : IdentityDbContext<Driver>
{

    public DbSet<Bus> Buses { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Entry> Entries { get; set; }
    public DbSet<Loop> Loops { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Stop> Stops { get; set; }
    public string Path { get; }

    public BusContext(DbContextOptions options) : base(options) { }

}