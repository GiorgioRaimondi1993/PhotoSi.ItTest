using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PhotoSi.Locations.UnitTest.Services;
using PhotoSi.Users.Application.Mappers;
using PhotoSi.Users.Application.Repositories;
using PhotoSi.Users.UnitTest.Scenario;
using PhotoSi.Users.UnitTest.Services;
using System.Reflection;
using Xunit;

namespace PhotoSi.Users.UnitTest;

[Collection(nameof(Users))]
public class UserBaseTest
{
    /// <summary>
    /// Service provider.
    /// </summary>
    protected IServiceProvider ServiceProvider { get; }

    protected UserScenario Scenario => ServiceProvider.GetRequiredService<UserScenario>();

    protected IMediator Mediator => ServiceProvider.GetRequiredService<IMediator>();

    public UserBaseTest()
    {
        ServiceCollection services = new();

        // Register Default Services

        Assembly applicationAssembly = typeof(MappingUser).Assembly;
        services.AddAutoMapper(applicationAssembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(applicationAssembly);
        });

        // Add mock Scenario and mocked Repositories       
        services
            .AddScoped<UserScenario>()
            .AddScoped<IUsersRepository, MockUsersRepository>()
            .AddScoped<ILocationsRepository, MockLocationsRepository>();

        ServiceProvider = services.BuildServiceProvider();
    }
}
