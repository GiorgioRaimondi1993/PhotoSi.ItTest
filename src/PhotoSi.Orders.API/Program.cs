using Microsoft.EntityFrameworkCore;
using PhotoSi.Orders.Application.Repositories;
using PhotoSi.Orders.Infrastracture.Repositories;
using PhotoSi.Orders.Infrastracture.Sql;
using System.Reflection;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var app = builder.Build();

        ConfigureServices(builder.Services, builder.Configuration);

        app.UseRouting();
        app.UseEndpoints(e => { e.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"); });

        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

        services.AddControllersWithViews();

        // Register Mapper and Mediator
        Assembly applicationAssembly = typeof(IOrdersRepository).Assembly;
        services.AddAutoMapper(applicationAssembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(applicationAssembly);
        });

        // Register Db Services
        services.AddDbContext<OrdersDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Orders"));
        });

        services.AddSingleton<IOrdersRepository, OrdersRepository>();
    }
}