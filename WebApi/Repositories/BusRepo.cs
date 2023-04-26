public class BusRepo
{
    private readonly DbContext _context;

    public BusRepo(DbContext context)
    {
        _context = context;
    }

    // Get all buses from the database
    public List<Bus> GetAllBuses()
    {
        return _context.Set<Bus>().ToList();
    }

    // Get a bus by its ID
    public Bus GetBusById(int id)
    {
        return _context.Set<Bus>().Find(id);
    }

    // Add a new bus to the database
    public void AddBus(Bus bus)
    {
        _context.Set<Bus>().Add(bus);
        _context.SaveChanges();
    }

    // Update a bus in the database
    public void UpdateBus(Bus bus)
    {
        _context.Entry(bus).State = EntityState.Modified;
        _context.SaveChanges();
    }

    // Delete a bus from the database
    public void DeleteBus(Bus bus)
    {
        _context.Set<Bus>().Remove(bus);
        _context.SaveChanges();
    }
}
