public class RouteRepo
{
    private readonly DbContext _context;

    public RouteRepo(DbContext context)
    {
        _context = context;
    }

    // Get all routes from the database
    public List<Route> GetAllRoutes()
    {
        return _context.Set<Route>().ToList();
    }

    // Get a route by its ID
    public Route GetRouteById(int id)
    {
        return _context.Set<Route>().Find(id);
    }

    // Add a new route to the database
    public void AddRoute(Route route)
    {
        _context.Set<Route>().Add(route);
        _context.SaveChanges();
    }

    // Update a route in the database
    public void UpdateRoute(Route route)
    {
        _context.Entry(route).State = EntityState.Modified;
        _context.SaveChanges();
    }

    // Delete a route from the database
    public void DeleteRoute(Route route)
    {
        _context.Set<Route>().Remove(route);
        _context.SaveChanges();
    }
}
