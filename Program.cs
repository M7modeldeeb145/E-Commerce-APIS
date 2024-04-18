
using E_Commerce.Data;
using E_Commerce.IRepository;
using E_Commerce.Models;
using E_Commerce.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString
                ("DefaultConnection")));


            builder.Services.AddScoped<IProduct,ProductRepository>();
            builder.Services.AddScoped<ICategory,CategoryRepository>();
            builder.Services.AddScoped<IContactUs,ContactUsRepository>();


            //builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Configure identity options here
                options.User.RequireUniqueEmail = true; // Ensure unique email addresses
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
