using Domain;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using Xunit;

public class BusRepoTests
{
    [Fact]
    public void GetAllBuses_ShouldReturnListOfBuses()
    {
        // Arrange
        var buses = new List<Bus>
        {
            new Bus { Id = 1, BusNumber = 1234 },
            new Bus { Id = 2, BusNumber = 5678 }
        };
        var dbContextOptions = new DbContextOptionsBuilder<BusContext>().UseInMemoryDatabase(databaseName: "GetAllBuses").Options;
        var context = new BusContext(dbContextOptions);
        context.AddRange(buses);
        context.SaveChanges();
        var busRepo = new BusRepo(context);

        // Act
        var result = busRepo.GetAllBuses();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(buses.Count, result.Count);
    }

    [Fact]
    public void GetBusById_ShouldReturnCorrectBus()
    {
        // Arrange
        var bus = new Bus { Id = 1, BusNumber = 1234 };
        var dbContextOptions = new DbContextOptionsBuilder<BusContext>().UseInMemoryDatabase(databaseName: "GetBusById").Options;
        var context = new BusContext(dbContextOptions);
        context.Add(bus);
        context.SaveChanges();
        var busRepo = new BusRepo(context);

        // Act
        var result = busRepo.GetBusById(bus.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(bus.BusNumber, result.BusNumber);
    }

    [Fact]
    public void AddBus_ShouldAddBusToDatabase()
    {
        // Arrange
        var bus = new Bus { Id = 1, BusNumber = 1234 };
        var dbContextOptions = new DbContextOptionsBuilder<BusContext>().UseInMemoryDatabase(databaseName: "AddBus").Options;
        var context = new BusContext(dbContextOptions);
        var busRepo = new BusRepo(context);

        // Act
        var result = busRepo.AddBus(bus);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(bus, result);
        Assert.Contains(bus, context.Set<Bus>());
    }

    [Fact]
    public void UpdateBus_ShouldUpdateBusInDatabase()
    {
        // Arrange
        var bus = new Bus { Id = 1, BusNumber = 1234 };
        var dbContextOptions = new DbContextOptionsBuilder<BusContext>().UseInMemoryDatabase(databaseName: "UpdateBus").Options;
        var context = new BusContext(dbContextOptions);
        context.Add(bus);
        context.SaveChanges();
        var busRepo = new BusRepo(context);

        // Act
        bus.BusNumber = 5678;
        var result = busRepo.UpdateBus(bus);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(bus, result);
        Assert.Equal(bus.BusNumber, context.Set<Bus>().Find(bus.Id).BusNumber);
    }

    [Fact]
    public void DeleteBus_ShouldDeleteBusFromDatabase()
    {
        // Arrange
        var bus = new Bus { Id = 1, BusNumber = 1234 };
        var dbContextOptions = new DbContextOptionsBuilder<BusContext>().UseInMemoryDatabase(databaseName: "DeleteBus").Options;
        var context = new BusContext(dbContextOptions);
        context.Add(bus);
        context.SaveChanges();
        var busRepo = new BusRepo(context);

        // Act
        busRepo.DeleteBus(bus.Id);

        // Assert
        Assert.DoesNotContain(bus, context.Set<Bus>());
    }
}
