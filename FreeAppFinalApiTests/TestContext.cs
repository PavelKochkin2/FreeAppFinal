using System;
using System.Net.Http;
using FreeAppFinal;
using FreeAppFinal.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace FreeAppFinalApiTests
{
    public class TestContext : IDisposable
    {
        public readonly ApplicationDbContext _context;
        public readonly HttpClient _httpClient;

        public TestContext()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            var server = new TestServer(builder);
            _context = server.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            _httpClient = server.CreateClient();
        }

        public void Dispose()
        {
            _context.Dispose();
            _httpClient.Dispose();
        }
    }
}