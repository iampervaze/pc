using PremiumCalculator.Web.Abstractions.Repository;
using PremiumCalculator.Web.Abstractions.Services;
using PremiumCalculator.Web.Repository;
using PremiumCalculator.Web.Services;

namespace PremiumCalculator.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var services = builder.Services;
            services.AddControllersWithViews();

            //repositories
            services.AddSingleton<IOccupationRepository, OccupationRepository>();

            //services
            services.AddSingleton<IPremiumCalculatorService, PremiumCalculatorService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();


            app.MapControllers();

            app.MapFallbackToFile("index.html"); ;

            app.Run();

        }
    }
}

