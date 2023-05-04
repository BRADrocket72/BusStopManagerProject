using Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests
{
    public class LoopRepoTests
    {
        private readonly DbContextOptions<BusContext> _options;

        public LoopRepoTests()
        {
            _options = new DbContextOptionsBuilder<BusContext>()
                .UseInMemoryDatabase(databaseName: "LoopDatabase")
                .Options;
        }

        [Fact]
        public void GetAllLoops_ShouldReturnAllLoops()
        {
            // Arrange
            using (var context = new BusContext(_options))
            {
                var loop1 = new Loop { Name = "Loop 1" };
                var loop2 = new Loop { Name = "Loop 2" };
                context.Loops.Add(loop1);
                context.Loops.Add(loop2);
                context.SaveChanges();

                var repository = new LoopRepo(context);

                // Act
                var loops = repository.GetAllLoops();

                // Assert
                Assert.Equal(4, loops.Count);
            }
        }

        [Fact]
        public void GetLoopById_ShouldReturnCorrectLoop()
        {
            // Arrange
            using (var context = new BusContext(_options))
            {
                var loop1 = new Loop { Name = "Loop 1" };
                var loop2 = new Loop { Name = "Loop 2" };
                context.Loops.Add(loop1);
                context.Loops.Add(loop2);
                context.SaveChanges();

                var repository = new LoopRepo(context);

                // Act
                var loop = repository.GetLoopById(loop1.Id);

                // Assert
                Assert.Equal(loop1.Name, loop.Name);
            }
        }

        [Fact]
        public void AddLoop_ShouldAddNewLoop()
        {
            // Arrange
            using (var context = new BusContext(_options))
            {
                var loop = new Loop { Name = "Loop 1" };
                var repository = new LoopRepo(context);

                // Act
                repository.AddLoop(loop);

                // Assert
                var loops = repository.GetAllLoops();
                Assert.Equal(loop.Name, loops[0].Name);
            }
        }

        [Fact]
        public void UpdateLoop_ShouldUpdateExistingLoop()
        {
            // Arrange
            using (var context = new BusContext(_options))
            {
                var loop = new Loop { Name = "Loop 1" };
                context.Loops.Add(loop);
                context.SaveChanges();

                var repository = new LoopRepo(context);
                loop.Name = "Updated Loop Name";

                // Act
                repository.UpdateLoop(loop);

                // Assert
                var updatedLoop = repository.GetLoopById(loop.Id);
                Assert.Equal("Updated Loop Name", updatedLoop.Name);
            }
        }

        [Fact]
        public void DeleteLoop_ShouldDeleteExistingLoop()
        {
            // Arrange
            using (var context = new BusContext(_options))
            {
                var loop = new Loop { Name = "Loop 1" };
                context.Loops.Add(loop);
                context.SaveChanges();

                var repository = new LoopRepo(context);

                // Act
                repository.DeleteLoop(loop.Id);

                // Assert
                var deletedLoop = repository.GetLoopById(loop.Id);
                Assert.Null(deletedLoop);
            }
        }
    }
}
