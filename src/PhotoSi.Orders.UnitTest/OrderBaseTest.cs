using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PhotoSi.Orders.Application.Repositories;
using PhotoSi.Orders.UnitTest.Scenario;
using PhotoSi.Orders.UnitTest.Services;
using System.Reflection;
using Xunit;

namespace PhotoSi.Orders.UnitTest;

[Collection(nameof(Orders))]
public class OrderBaseTest
{
    /// <summary>
    /// Service provider.
    /// </summary>
    protected IServiceProvider ServiceProvider { get; }

    protected OrderScenario Scenario => ServiceProvider.GetRequiredService<OrderScenario>();

    protected IMediator Mediator => ServiceProvider.GetRequiredService<IMediator>();

    public OrderBaseTest()
    {
        ServiceCollection services = new();

        // Register Default Services

        Assembly applicationAssembly = typeof(IOrdersRepository).Assembly;
        services.AddAutoMapper(applicationAssembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(applicationAssembly);
        });

        // Add mock Scenario and mocked Repositories       
        services
            .AddScoped<OrderScenario>()
            .AddScoped<IOrdersRepository, MockOrderRepository>();

        ServiceProvider = services.BuildServiceProvider();
    }
}
