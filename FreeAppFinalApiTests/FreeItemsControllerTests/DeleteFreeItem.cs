using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FreeAppFinal.Models;
using Xunit;

namespace FreeAppFinalApiTests.FreeItemsControllerTests
{
    public class DeleteFreeItem : IClassFixture<TestContext>
    {
        private readonly TestContext _testContext;
        public DeleteFreeItem(TestContext testContext)
        {
            _testContext = testContext;
        }

        [Fact]
        public async Task DoesReturnOk_GivenFreeItemExists()
        {
            var item = new FreeItem {Description = "Delete", Id = 1, Name = "Delete"};

            _testContext.DbContext.FreeItems.Add(item);
            _testContext.DbContext.SaveChanges();

            HttpResponseMessage response = await _testContext.HttpClient.DeleteAsync($"api/FreeItems/{item.Id}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}