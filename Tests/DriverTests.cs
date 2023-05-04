using Xunit;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WebApi;
using Domain;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Domain;

namespace Tests
{
    public class DriverControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Program> _factory;

        public DriverControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllDrivers_ReturnsSuccessStatusCode()
        {
            // Arrange
            var request = "/Driver/GetAll";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetDriverById_ReturnsNotFoundStatusCode()
        {
            // Arrange
            var request = "/Driver/GetDriverById?id=1";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateDriver_ReturnsSuccessStatusCode()
        {
            // Arrange
            var driver = new Driver { FirstName = "John", LastName = "Doe", IsAdmin = false };
            var json = JsonConvert.SerializeObject(driver);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            var request = "/Driver/CreateDriver";

            // Act
            var response = await _client.PostAsync(request, requestContent);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var driverInfo = JsonConvert.DeserializeObject<Driver>(responseString);
            Assert.Equal("John", driverInfo.FirstName);
            Assert.Equal("Doe", driverInfo.LastName);
        }

        [Fact]
        public async Task UpdateDriver_ReturnsBadRequestStatusCode()
        {
            // Arrange
            var driver = new Driver { Id = 1, FirstName = "John", LastName = "Doe", IsAdmin = false };
            var json = JsonConvert.SerializeObject(driver);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            var request = "/Driver/Update/UpdateDriver";

            // Act
            var response = await _client.PostAsync(request, requestContent);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task DeleteDriver_ReturnsSuccessStatusCode()
        {
            // Arrange
            var driver = new Driver { FirstName = "John", LastName = "Doe", IsAdmin = false };
            var addedDriver = await AddDriver(driver);
            var request = $"/Driver/Delete/Driver?driverId={addedDriver.Id}";

            // Act
            var response = await _client.DeleteAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("Driver successfully deleted.", responseString);
        }

        private async Task<Driver> AddDriver(Driver driver)
        {
            var json = JsonConvert.SerializeObject(driver);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            var request = "/Driver/CreateDriver";

            var response = await _client.PostAsync(request, requestContent);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Driver>(responseString);
        }
    }
}
