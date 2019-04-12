using FreeAppFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeAppFinal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(P-KOCHKIN);Database=helloappdb;Trusted_Connection=True;");
        //}

        public DbSet<FreeItem> FreeItems { get; set; }
    }
}