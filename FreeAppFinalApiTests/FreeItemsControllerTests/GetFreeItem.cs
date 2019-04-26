using System.Net;
using System.Threading.Tasks;
using FreeAppFinal.Models;
using Newtonsoft.Json;
using Xunit;

namespace FreeAppFinalApiTests.FreeItemsControllerTests
{
    public class GetFreeItem : IClassFixture<TestContext>
    {
        private readonly TestContext _testContext;

        public GetFreeItem(TestContext testContext)
        {
            this._testContext = testContext;
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

            _testContext.DbContext.FreeItems.Add(item);
            _testContext.DbContext.SaveChanges();

            //Act
            var response = await _testContext.HttpClient.GetAsync($"/api/FreeItems/{item.Id}");

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
            //todo: add method to get id which does not exist

            //Act
            var response = await _testContext.HttpClient.GetAsync($"/api/FreeItems/99999");

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
