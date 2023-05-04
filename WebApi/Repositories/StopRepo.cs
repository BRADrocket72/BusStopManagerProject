using Domain;
using Microsoft.EntityFrameworkCore;

public class StopRepo : IStopRepo
{
    private readonly BusContext _context;

    public StopRepo(BusContext context)
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
    public Stop AddStop(Stop stop)
    {
        _context.Set<Stop>().Add(stop);
        _context.SaveChanges();
        return stop;
    }

    // Update a stop in the database
    public Stop UpdateStop(Stop stop)
    {
        _context.Entry(stop).State = EntityState.Modified;
        _context.SaveChanges();
        return stop;
    }

    // Delete a stop from the database
    public void DeleteStop(int stopId)
    {
        var stop = _context.Set<Stop>().Find(stopId);
        if (stop != null)
        {
            _context.Set<Stop>().Remove(stop);
            _context.SaveChanges();
        }
    }
}
