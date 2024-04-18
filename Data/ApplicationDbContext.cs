using E_Commerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImages> ProductImages  { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public ApplicationDbContext(){}
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options):base(options){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json")
               .Build().GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(builder);
        }
    }
}
