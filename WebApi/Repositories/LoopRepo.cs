public class LoopRepo
{
    private readonly DbContext _context;

    public LoopRepo(DbContext context)
    {
        _context = context;
    }

    // Get all loops from the database
    public List<Loop> GetAllLoops()
    {
        return _context.Set<Loop>().ToList();
    }

    // Get a loop by its ID
    public Loop GetLoopById(int id)
    {
        return _context.Set<Loop>().Find(id);
    }

    // Add a new loop to the database
    public void AddLoop(Loop loop)
    {
        _context.Set<Loop>().Add(loop);
        _context.SaveChanges();
    }

    // Update a loop in the database
    public void UpdateLoop(Loop loop)
    {
        _context.Entry(loop).State = EntityState.Modified;
        _context.SaveChanges();
    }

    // Delete a loop from the database
    public void DeleteLoop(Loop loop)
    {
        _context.Set<Loop>().Remove(loop);
        _context.SaveChanges();
    }
}
