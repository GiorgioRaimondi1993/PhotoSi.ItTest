using Microsoft.EntityFrameworkCore;
using PhotoSi.Users.Application.Mappers;
using PhotoSi.Users.Application.Repositories;
using PhotoSi.Users.Infrastracture.Repositories;
using PhotoSi.Users.Infrastracture.Sql;
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
            await using var dbCtx = serviceScope.ServiceProvider.GetRequiredService<UsersDbContext>();
            await dbCtx.Database.MigrateAsync();
        }
    }

    private static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

        services.AddControllersWithViews();

        // Register Mapper and Mediator
        Assembly applicationAssembly = typeof(MappingUser).Assembly;
        services.AddAutoMapper(applicationAssembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(applicationAssembly);
        });

        // Register Db Services

        services.AddDbContext<UsersDbContext>(opt =>
        {
            opt.ConfigureLoggingCacheTime(TimeSpan.FromMinutes(10))
               .UseSqlServer(connectionString: configuration.GetConnectionString("Users"));
        });

        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<ILocationsRepository, LocationsRepository>();
    }
}