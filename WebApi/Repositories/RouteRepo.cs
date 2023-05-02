using Domain;
using Microsoft.EntityFrameworkCore;
using Route = Domain.Route;

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
    public Route AddRoute(Route route)
    {
        _context.Set<Route>().Add(route);
        _context.SaveChanges();
        return route;
    }

    // Update a route in the database
    public Route UpdateRoute(Route route)
    {
        _context.Entry(route).State = EntityState.Modified;
        _context.SaveChanges();
        return route;
    }

    // Delete a route from the database
    public void DeleteRoute(int routeId)
    {
        var route = _context.Set<Route>().Find(routeId);
        if (route != null)
        {
            _context.Set<Route>().Remove(route);
            _context.SaveChanges();
        }
    }
}
