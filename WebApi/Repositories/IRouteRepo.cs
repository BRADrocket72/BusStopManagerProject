public interface IRouteRepo
{
    Domain.Route AddRoute(Domain.Route route);
    void DeleteRoute(int routeId);
    List<Domain.Route> GetAllRoutes();
    Domain.Route GetRouteById(int id);
    Domain.Route UpdateRoute(Domain.Route route);
}