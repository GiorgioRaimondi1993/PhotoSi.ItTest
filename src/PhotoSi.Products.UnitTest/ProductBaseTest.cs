using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PhotoSi.Products.Application.Mappers;
using PhotoSi.Products.Application.Repositories;
using PhotoSi.Products.UnitTest.Scenario;
using PhotoSi.Products.UnitTest.Services;
using System.Reflection;
using Xunit;

namespace PhotoSi.Products.UnitTest;

[Collection(nameof(Products))]
public class ProductBaseTest
{
    /// <summary>
    /// Service provider.
    /// </summary>
    protected IServiceProvider ServiceProvider { get; }

    protected ProductsScenario Scenario => ServiceProvider.GetRequiredService<ProductsScenario>();

    protected IMediator Mediator => ServiceProvider.GetRequiredService<IMediator>();

    public ProductBaseTest()
    {
        ServiceCollection services = new();

        // Register Default Services

        Assembly applicationAssembly = typeof(MappingProducts).Assembly;
        services.AddAutoMapper(applicationAssembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(applicationAssembly);
        });

        // Add mock Scenario and mocked Repositories       
        services
            .AddScoped<ProductsScenario>()
            .AddScoped<IProductsRepository, MockProductsRepository>();

        ServiceProvider = services.BuildServiceProvider();
    }
}
