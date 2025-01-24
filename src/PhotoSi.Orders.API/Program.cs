using Microsoft.EntityFrameworkCore;
using PhotoSi.Orders.Application.Mappers;
using PhotoSi.Orders.Application.Repositories;
using PhotoSi.Orders.Infrastracture.Repositories;
using PhotoSi.Orders.Infrastracture.Sql;
using System.Reflection;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder.Services, builder.Configuration);

        var app = builder.Build();

        EnsureMigration(app).GetAwaiter().GetResult();

        app.UseRouting();
        app.UseEndpoints(e => { e.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"); });

        app.Run();
    }

    private static async Task EnsureMigration(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            await using var serviceScope = app.Services.CreateAsyncScope();
            await using var dbCtx = serviceScope.ServiceProvider.GetRequiredService<OrdersDbContext>();
            await dbCtx.Database.MigrateAsync();
        }
    }

    private static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

        services.AddControllersWithViews();

        // Register Mapper and Mediator
        Assembly applicationAssembly = typeof(MappingOrders).Assembly;
        services.AddAutoMapper(applicationAssembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(applicationAssembly);
        });

        // Register Db Services
        services.AddDbContext<OrdersDbContext>(opt =>
        {
            opt.ConfigureLoggingCacheTime(TimeSpan.FromMinutes(10))
               .UseSqlServer(configuration.GetConnectionString("Orders"));
        });

        services.AddScoped<IOrdersRepository, OrdersRepository>();
    }
}