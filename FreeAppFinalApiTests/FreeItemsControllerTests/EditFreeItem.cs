using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FreeAppFinal.Models;
using Newtonsoft.Json;
using Xunit;

namespace FreeAppFinalApiTests.FreeItemsControllerTests
{
    public class EditFreeItem : IClassFixture<TestContext>
    {
        private readonly TestContext _testContext;

        public EditFreeItem(TestContext testContext)
        {
            _testContext = testContext;
        }

        [Fact]
        public async Task DoesReturnOk_GivenFreeItemExists()
        {
            //Arrange
            var item = new FreeItem { Description = "Item", Name = "Name" };

            _testContext.DbContext.FreeItems.Add(item);
            _testContext.DbContext.SaveChanges();

            var editedItem = new FreeItem { Description = "EditedItem", Name = "EditedName" };

            var stringEditedItem = new StringContent(JsonConvert.SerializeObject(editedItem), Encoding.UTF8, "application/json");
            
            //Act
            var response = await _testContext.HttpClient.PutAsync($"api/FreeItems/{item.Id}", stringEditedItem);

            string jsonResult = await response.Content.ReadAsStringAsync();
            var freeItemFromJson = JsonConvert.DeserializeObject<FreeItem>(jsonResult);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(editedItem.Name, freeItemFromJson.Name);
            Assert.Equal(editedItem.Description, freeItemFromJson.Description);
        }

        [Fact]
        public async Task DoesReturnNotFound_GivenFreeItemDoesNotExist()
        {
            //Arrange
            var item = new FreeItem { Description = "Item", Name = "Item" };

            var stringEditedItem = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");

            //Act
            var response = await _testContext.HttpClient.PutAsync($"api/FreeItems/5555", stringEditedItem);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}