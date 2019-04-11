using System.Net;
using System.Net.Http;
using FreeAppFinal;
using FreeAppFinal.Data;
using FreeAppFinal.Models;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FreeAppFinalApiTests
{
    public class FreeItemsControllerGetFreeItem
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;

        public FreeItemsControllerGetFreeItem()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            var server = new TestServer(builder);
            _context = server.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            _httpClient = server.CreateClient();
        }

        [Fact]
        public async Task DoesReturnOk_GivenFreeItemExists()
        {
            //Arrange
            var item = new FreeItem
            {
                Description = "Description",
                Id = 1,
                Name = "Item1"
            };

            _context.FreeItems.Add(item);
            _context.SaveChanges();

            //Act
            var response = await _httpClient.GetAsync($"/api/FreeItems/{item.Id}");

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            FreeItem itemFromJson = JsonConvert.DeserializeObject<FreeItem>(jsonResult);
            Assert.Equal(item.Id, itemFromJson.Id);
            Assert.Equal(item.Description, itemFromJson.Description);
            Assert.Equal(item.Name, itemFromJson.Name);
        }

        [Fact]
        public async Task DoesReturnNotFound_GivenFreeItemDoesNotExist()
        {
            //Arrange
            //get id which doesn't exist

            //Act
            var response = await _httpClient.GetAsync($"/api/FreeItems/99999");

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
