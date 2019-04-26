using System;
using System.Net.Http;
using FreeAppFinal;
using FreeAppFinal.Data;
using FreeAppFinal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace FreeAppFinalApiTests
{
    public class TestContext : IDisposable
    {
        public ApplicationDbContext DbContext { get; }
        public HttpClient HttpClient { get; }

        public TestContext()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            var server = new TestServer(builder);
            DbContext = server.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            HttpClient = server.CreateClient();


            //todo: add shared item to test context in order not to create one for testing
            //if (DbContext != null)
            //{
            //    DbContext.FreeItems.Add(new FreeItem() {Description = "Test", Id = 1, Name = "Test"});
            //    DbContext.SaveChanges();
            //}
        }

        public void Dispose()
        {
            //DbContext.Dispose();
            //HttpClient.Dispose();
        }
    }
}