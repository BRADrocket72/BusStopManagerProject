using Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class RouteRepoTests
{
    [Fact]
    public void TestGetAllRoutes()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<BusContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

        using var context = new BusContext(options);
        var routeRepo = new RouteRepo(context);
        var stop = new Stop { Name = "Stop 1", Latitude = 1.0, Longitude = 2.0 };
        var route1 = new Route { Order = 1, Stop = stop };
        var route2 = new Route { Order = 2, Stop = stop };
        context.Routes.Add(route1);
        context.Routes.Add(route2);
        context.SaveChanges();

        // Act
        var routes = routeRepo.GetAllRoutes();

        // Assert
        Assert.Equal(2, routes.Count);
    }

    [Fact]
    public void TestGetRouteById()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<BusContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

        using var context = new BusContext(options);
        var routeRepo = new RouteRepo(context);
        var stop = new Stop { Name = "Stop 1", Latitude = 1.0, Longitude = 2.0 };
        var route = new Route { Order = 1, Stop = stop };
        context.Routes.Add(route);
        context.SaveChanges();

        // Act
        var result = routeRepo.GetRouteById(route.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(route.Id, result.Id);
    }

    [Fact]
    public void TestAddRoute()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<BusContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

        using var context = new BusContext(options);
        var routeRepo = new RouteRepo(context);
        var stop = new Stop { Name = "Stop 1", Latitude = 1.0, Longitude = 2.0 };
        var route = new Route { Order = 1, Stop = stop };

        // Act
        var result = routeRepo.AddRoute(route);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(route, result);
    }

    [Fact]
    public void TestUpdateRoute()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<BusContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

        using var context = new BusContext(options);
        var routeRepo = new RouteRepo(context);
        var stop = new Stop { Name = "Stop 1", Latitude = 1.0, Longitude = 2.0 };
        var route = new Route { Order = 1, Stop = stop };
        context.Routes.Add(route);
        context.SaveChanges();

        // Act
        route.Order = 2;
        var result = routeRepo.UpdateRoute(route);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(route, result);
        Assert.Equal(2, result.Order);
    }
}
