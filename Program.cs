using Admin_Portfolio.Data.DBContexts;
using Admin_Portfolio.Identity;
using Microsoft.AspNetCore.Identity;

namespace Admin_Portfolio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext
                <PortfolioContext>();
            builder.Services.AddControllersWithViews();

            
            //  builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>()
            //.AddEntityFrameworkStores<PortfolioContext>()
            //.AddDefaultTokenProviders();
            var app = builder.Build();
            app.UseMiddleware<AuthenticationMiddleware>();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Index}/{id?}");

            app.Run();
        }
    }
}