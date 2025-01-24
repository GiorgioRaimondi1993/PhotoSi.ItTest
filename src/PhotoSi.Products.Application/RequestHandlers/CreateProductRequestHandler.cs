using MediatR;
using PhotoSi.Products.Application.Models;
using PhotoSi.Products.Application.Repositories;
using PhotoSi.Products.Application.Requests;

namespace PhotoSi.Products.Application.RequestHandlers;
public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, Guid>
{
    private readonly IProductsRepository _productsRepository;

    public CreateProductRequestHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<Guid> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        Product location = Product.Create(request.Name,
                                          request.Category);

        await _productsRepository.AddAsync(location);

        return location.Id;
    }
}
