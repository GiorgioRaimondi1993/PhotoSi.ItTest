using Ocelot.DependencyInjection;
using Ocelot.Middleware;

internal class Program
{
    private async static Task Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        ConfigurationManager config = builder.Configuration;

        config.AddJsonFile("ocelot.json", false, false);

        ConfigureServices(builder.Services);

        WebApplication app = builder.Build();

        await ConfigureAsync(app, builder.Environment);

        await app.RunAsync();
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddOcelot();
    }

    public async static Task ConfigureAsync(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        await app.UseOcelot();
    }
}