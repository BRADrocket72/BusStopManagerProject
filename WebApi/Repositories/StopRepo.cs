using Domain;
using Microsoft.EntityFrameworkCore;

public class StopRepo
{
    private readonly DbContext _context;

    public StopRepo(DbContext context)
    {
        _context = context;
    }

    // Get all stops from the database
    public List<Stop> GetAllStops()
    {
        return _context.Set<Stop>().ToList();
    }

    // Get a stop by its ID
    public Stop GetStopById(int id)
    {
        return _context.Set<Stop>().Find(id);
    }

    // Add a new stop to the database
    public void AddStop(Stop stop)
    {
        _context.Set<Stop>().Add(stop);
        _context.SaveChanges();
    }

    // Update a stop in the database
    public void UpdateStop(Stop stop)
    {
        _context.Entry(stop).State = EntityState.Modified;
        _context.SaveChanges();
    }

    // Delete a stop from the database
    public void DeleteStop(Stop stop)
    {
        _context.Set<Stop>().Remove(stop);
        _context.SaveChanges();
    }
}
