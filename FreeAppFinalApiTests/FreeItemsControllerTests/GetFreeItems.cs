using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FreeAppFinal.Models;
using Xunit;

namespace FreeAppFinalApiTests.FreeItemsControllerTests
{
    public class GetFreeItems : IClassFixture<TestContext>
    {
        private readonly TestContext _testContext;
        public GetFreeItems(TestContext testContext)
        {
            _testContext = testContext;
        }

        [Fact]
        public async Task DoesReturnOk_GivenFreeItemExistsInDb()
        {
            //Arrange
            _testContext.DbContext.FreeItems.Add(new FreeItem() { Description = "Test", Id = 1, Name = "Test" });
            _testContext.DbContext.SaveChanges();

            //Act
            var response = await _testContext.HttpClient.GetAsync("api/FreeItems");

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DoesReturnNotFound_GivenFreeItemDoesNotExist()
        {
            //Arrange

            //Act
            var response = await _testContext.HttpClient.GetAsync("api/FreeItems");

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}