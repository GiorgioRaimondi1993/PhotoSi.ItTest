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

        app.UseRouting();
        app.UseEndpoints(e => { e.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"); });


        ApplyMigrations(app);

        app.Run();
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
               .UseSqlServer(connectionString: configuration.GetConnectionString("SqlServer"));
        });

        services.AddScoped<IProductsRepository, ProductsRepository>();
    }

    private static void ApplyMigrations(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            using var serviceScope = app.Services.CreateScope();
            using var dbCtx = serviceScope.ServiceProvider.GetRequiredService<ProductsDbContext>();
            dbCtx.Database.Migrate();
        }
    }
}