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
        Assembly applicationAssembly = typeof(MappingUser).Assembly;
        services.AddAutoMapper(applicationAssembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(applicationAssembly);
        });

        // Register Db Services
        services.AddDbContext<UsersDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Users"));
        });

        services.AddSingleton<IUsersRepository, UsersRepository>();
        services.AddSingleton<ILocationsRepository, LocationsRepository>();
    }
}