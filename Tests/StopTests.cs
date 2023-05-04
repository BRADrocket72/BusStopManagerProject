using System.Collections.Generic;
using Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class StopRepoTests
{
    private DbContextOptions<BusContext> _options;

    public StopRepoTests()
    {
        _options = new DbContextOptionsBuilder<BusContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
    }

    [Fact]
    public void TestGetStopById()
    {
        // Arrange
        using (var context = new BusContext(_options))
        {
            var repo = new StopRepo(context);
            var expectedStop = new Stop { Id = 1, Name = "Stop 1", Latitude = 12.345, Longitude = 67.890 };
            context.Set<Stop>().Add(expectedStop);
            context.SaveChanges();

            // Act
            var actualStop = repo.GetStopById(1);

            // Assert
            Assert.Equal(expectedStop, actualStop);
        }
    }
}
