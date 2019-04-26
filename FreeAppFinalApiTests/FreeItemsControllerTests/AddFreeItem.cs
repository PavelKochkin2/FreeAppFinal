using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FreeAppFinal.Models;
using Newtonsoft.Json;
using Xunit;

namespace FreeAppFinalApiTests.FreeItemsControllerTests
{
    public class AddFreeItem : IClassFixture<TestContext>
    {
        private readonly TestContext _testContext;

        public AddFreeItem(TestContext testContext)
        {
            _testContext = testContext;
        }

        [Fact]
        public async Task DoesReturnOk_GivenFreeItemIsValidAsync()
        {
            //Arrange
            var item = new FreeItem()
            {
                Description = "privet",
                Id = 23,
                Name = "Privet"
            };


            var stringContent = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");

            //Act
            var response = await _testContext.HttpClient.PostAsync("/api/FreeItems/", stringContent);

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            FreeItem itemFromJson = JsonConvert.DeserializeObject<FreeItem>(jsonResult);
            Assert.Equal(item.Id, itemFromJson.Id);
            Assert.Equal(item.Description, itemFromJson.Description);
            Assert.Equal(item.Name, itemFromJson.Name);
        }
    }
}