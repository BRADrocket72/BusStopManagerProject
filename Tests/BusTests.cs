using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Domain;

namespace WebApi.Tests
{
    public class BusControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BusControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetAllBusses_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Bus/GetAll");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetBusById_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();
            int id = 1;

            // Act
            var response = await client.GetAsync($"/Bus/GetBusById?id={id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetBusById_ReturnsNotFoundStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();
            int id = 999;

            // Act
            var response = await client.GetAsync($"/Bus/GetBusById?id={id}");

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateBus_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();
            var bus = new Bus { Id = 1, BusNumber = 1 };
            var content = new StringContent(JsonSerializer.Serialize(bus), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/Bus/CreateBus", content);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task UpdateBusInfo_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();

            var bus = new Bus { Id = 1, BusNumber = 1 };
            var content = new StringContent(JsonSerializer.Serialize(bus), Encoding.UTF8, "application/json");

            // Act
            await client.PostAsync("/Bus/CreateBus", content);
            var response = await client.PostAsync("/Bus/Update/UpdateBusInfo", content);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task DeleteBus_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();
            int id = 1;

            // Act
            var response = await client.PostAsync($"/Bus/Delete/Bus?id={id}", null);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
