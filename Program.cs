using AssetTrackingEFMVC.Data;
using AssetTrackingEFMVC.Repositorys;
using AssetTrackingEFMVC.Services;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackingEFMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IAssetService, AssetService>();
            builder.Services.AddScoped<IAssetRepository, AssetRepository>();
            builder.Services.AddScoped<IOfficeRepository, OfficeRepository>();
            builder.Services.AddScoped<IOfficeService, OfficeService>();


            builder.Services.AddDbContext<AssetsContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("assetsDB")));

            var app = builder.Build();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Assets}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
