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

        app.UseRouting();
        app.UseEndpoints(e => { e.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"); });

        ApplyMigrations(app);

        app.Run();
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
                   .UseSqlServer(connectionString: configuration.GetConnectionString("SqlServer"));
        });

        services.AddScoped<IOrdersRepository, OrdersRepository>();
    }

    private static void ApplyMigrations(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            using var serviceScope = app.Services.CreateScope();
            using var dbCtx = serviceScope.ServiceProvider.GetRequiredService<OrdersDbContext>();
            dbCtx.Database.Migrate();
        }
    }
}