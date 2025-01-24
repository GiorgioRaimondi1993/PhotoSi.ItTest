using Microsoft.EntityFrameworkCore;
using PhotoSi.Products.Application.Mappers;
using PhotoSi.Products.Application.Repositories;
using PhotoSi.Products.Infrastracture.Repositories;
using PhotoSi.Products.Infrastracture.Sql;
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
            await using var dbCtx = serviceScope.ServiceProvider.GetRequiredService<ProductsDbContext>();
            await dbCtx.Database.MigrateAsync();
        }
    }

    private static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

        services.AddControllersWithViews();

        // Register Default Services

        Assembly applicationAssembly = typeof(MappingProducts).Assembly;
        services.AddAutoMapper(applicationAssembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(applicationAssembly);
        });

        // Register SQL and Repositories

        services.AddDbContext<ProductsDbContext>(opt =>
        {
            opt.ConfigureLoggingCacheTime(TimeSpan.FromMinutes(10))
               .UseSqlServer(configuration.GetConnectionString("Products"));
        });

        services.AddScoped<IProductsRepository, ProductsRepository>();
    }
}