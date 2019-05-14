using System.Linq;
using FreeAppFinal.Models;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
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


        //todo: is it fine dispose? 
        public override void Dispose()
        {
        }

        public DbSet<FreeItem> FreeItems { get; set; }

        public DbSet<User> Users { get; set; }
    }
}