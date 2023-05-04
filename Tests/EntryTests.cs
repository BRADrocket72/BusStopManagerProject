using Domain;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class EntryControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public EntryControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetAllEntries_ReturnsSuccessStatusCode()
        {
            var entry = GenerateEntry();

            var content = new StringContent(JsonConvert.SerializeObject(entry), Encoding.UTF8, "application/json");

            await _client.PostAsync("/Entry/CreateEntry", content);
            // Arrange
            var request = "/Entry/GetAll";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetAllEntries_ReturnsCorrectContentType()
        {
            var entry = GenerateEntry();

            var content = new StringContent(JsonConvert.SerializeObject(entry), Encoding.UTF8, "application/json");

            await _client.PostAsync("/Entry/CreateEntry", content);
            // Arrange
            var request = "/Entry/GetAll";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task GetAllEntries_ReturnsListOfEntries()
        {
            var entry = GenerateEntry();

            var content = new StringContent(JsonConvert.SerializeObject(entry), Encoding.UTF8, "application/json");

            await _client.PostAsync("/Entry/CreateEntry", content);
            // Arrange
            var request = "/Entry/GetAll";

            // Act
            var response = await _client.GetAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var entries = JsonConvert.DeserializeObject<List<Entry>>(responseContent);

            // Assert
            Assert.NotNull(entries);
            Assert.IsType<List<Entry>>(entries);
            Assert.True(entries.Count > 0);
        }

        [Fact]
        public async Task GetEntryById_ReturnsSuccessStatusCode()
        {
            var entry = GenerateEntry();

            var content = new StringContent(JsonConvert.SerializeObject(entry), Encoding.UTF8, "application/json");

            await _client.PostAsync("/Entry/CreateEntry", content);
            // Arrange
            var id = 1;
            var request = $"/Entry/GetEntryById?id={id}";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetEntryById_ReturnsCorrectContentType()
        {
            var entry = GenerateEntry();

            var content = new StringContent(JsonConvert.SerializeObject(entry), Encoding.UTF8, "application/json");

            await _client.PostAsync("/Entry/CreateEntry", content);
            // Arrange
            var id = 1;
            var request = $"/Entry/GetEntryById?id={id}";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task GetEntryById_ReturnsEntryWithMatchingId()
        {
            var content = new StringContent(JsonConvert.SerializeObject(GenerateEntry()), Encoding.UTF8, "application/json");

            await _client.PostAsync("/Entry/CreateEntry", content);
            var id = 1;
            var request = $"/Entry/GetEntryById?id={id}";

            // Act
            var response = await _client.GetAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var entry = JsonConvert.DeserializeObject<Entry>(responseContent);

            // Assert
            Assert.NotNull(entry);
            Assert.IsType<Entry>(entry);
            Assert.Equal(id, entry.Id);
        }

        [Fact]
        public async Task GetEntryById_ReturnsNotFoundIfEntryDoesNotExist()
        {
            // Arrange
            var id = 999;
            var request = $"/Entry/GetEntryById?id={id}";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateEntry_ShouldCreateNewEntry_WhenValidEntryIsProvided()
        {
            // Arrange
            var entry = GenerateEntry();

            var content = new StringContent(JsonConvert.SerializeObject(entry), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/Entry/CreateEntry", content);
            var responseContent = await response.Content.ReadAsStringAsync();
        
            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            var resultEntry = JsonConvert.DeserializeObject<Entry>(responseContent);
            Assert.NotNull(resultEntry);
            Assert.True(resultEntry.Id > 0);
        }

        private Entry GenerateEntry()
        {
            return new Entry
            {
                TimeStamp = DateTime.UtcNow,
                Boarded = 10,
                LeftBehind = 5,
                Bus = new Bus
                {
                    BusNumber = 123
                },
                Loop = new Loop
                {
                    Name = "Test Loop",
                    Routes = new System.Collections.Generic.List<Route>
                    {
                        new Route
                        {
                            Order = 1,
                            Stop = new Stop
                            {
                                Name = "Test Stop",
                                Latitude = 42.123456,
                                Longitude = -71.123456
                            }
                        }
                    }
                },
                Stop = new Stop
                {
                    Name = "Test Stop",
                    Latitude = 42.123456,
                    Longitude = -71.123456
                }
            };
        }
    }
}

