using BookFindingAndRatingSystem.Data.Models;
using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.Data;
using BookFindingAndRatingSystem.Web.Infrastucture.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using static BookFindingAndRatingSystem.Common.GeneralApplicationConstansts;
using BookFindingAndRatingSystem.Web.Hubs;
using Ganss.Xss;

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
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<BooksDbContext>();

            builder.Services.AddApllicationServices(typeof(IBookService));
            

            builder.Services.AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();

                });
            builder.Services.AddSignalR();

            builder.Services.AddSingleton<IHtmlSanitizer, HtmlSanitizer>();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.SeedAdministrator(DevelopmentAdminEmail);
            app.UseEndpoints(config =>
            {
                config.MapControllerRoute(
                 name: "areas",
                 pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
               );
                config.MapControllerRoute(
                             name: "default",
                             pattern: "{controller=Home}/{action=Index}/{id?}");
                config.MapRazorPages();
            });


            app.MapHub<ChatHub>("/chatHub");
            app.Run();
        }
    }
}