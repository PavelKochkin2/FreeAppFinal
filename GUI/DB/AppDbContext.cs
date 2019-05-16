using GUI.Models;
using Microsoft.EntityFrameworkCore;

namespace GUI.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<FreeItem> FreeItems { get; set; }

        public DbSet<User> Users { get; set; }
    }
}