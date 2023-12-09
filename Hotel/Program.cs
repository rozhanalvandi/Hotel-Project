using Hotel.Core;
using Hotel.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Hotel;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddDbContext<MyContext>(op =>
               op.UseSqlite(builder.Configuration.GetConnectionString("AppDbContext")));

        builder.Services.AddScoped<IHotelService, HotelService>();


        builder.Services.AddControllersWithViews();
        builder.Services.AddAuthentication(option =>

        {
            option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        }).AddCookie(option =>
        {
            option.LoginPath = "/Login";
            option.LogoutPath = "/Logout";
            option.ExpireTimeSpan = TimeSpan.FromDays(10);
        }); 

       
        
        var app = builder.Build();

        app.UseStaticFiles();
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        
        app.UseEndpoints(endpints =>
        {
            endpints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{Id?}");


            endpints.MapControllerRoute(
            name: "Default",
            pattern:"{controller=Home}/{action=Index}/{Id?}");
        });

        app.Run();
    }
}

