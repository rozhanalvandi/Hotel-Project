using Hotel.Data;
using Microsoft.EntityFrameworkCore;

namespace Hotel;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddDbContext<MyContext>(op =>
               op.UseSqlite(builder.Configuration.GetConnectionString("AppDbContext")));
        builder.Services.AddControllersWithViews();
        var app = builder.Build();

        app.UseStaticFiles();
        app.UseRouting();
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

