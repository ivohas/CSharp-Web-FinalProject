using BookFindingAndRatingSystem.Data.Models;
using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.Data;
using BookFindingAndRatingSystem.Web.Infrastucture.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BookFindingAndRatingSystem.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connectionString =
                builder.Configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<BooksDbContext>(options =>
                options.UseSqlServer(connectionString));
           
            builder.Services.AddDefaultIdentity<AplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount
                    = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireNonAlphanumeric
                    = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequireLowercase
                    = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase
                    = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequiredLength
                    = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");

            })
                .AddEntityFrameworkStores<BooksDbContext>();

            builder.Services.AddApllicationServices(typeof(IBookService));

            builder.Services.AddControllersWithViews();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}