using Domain;
using Microsoft.EntityFrameworkCore;

public class DriverRepo
{
    private readonly DbContext _context;

    public DriverRepo(DbContext context)
    {
        _context = context;
    }

    // Get all drivers from the database
    public List<Driver> GetAllDrivers()
    {
        return _context.Set<Driver>().ToList();
    }

    // Get a driver by their ID
    public Driver GetDriverById(int id)
    {
        return _context.Set<Driver>().Find(id);
    }

    // Add a new driver to the database
    public Driver AddDriver(Driver driver)
    {
        _context.Set<Driver>().Add(driver);
        _context.SaveChanges();
        return driver;
    }

    // Update a driver in the database
    public Driver UpdateDriver(Driver driver)
    {
        _context.Entry(driver).State = EntityState.Modified;
        _context.SaveChanges();
        return driver;
    }

    // Delete a driver from the database
    public void DeleteDriver(int driverId)
    {
        var driver = _context.Set<Driver>().Find(driverId);
        if (driver != null)
        {
            _context.Set<Driver>().Remove(driver);
            _context.SaveChanges();
        }
    }
}
