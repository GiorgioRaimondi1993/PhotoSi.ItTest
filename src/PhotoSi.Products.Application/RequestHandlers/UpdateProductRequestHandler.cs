using MediatR;
using PhotoSi.Products.Application.Models;
using PhotoSi.Products.Application.Repositories;
using PhotoSi.Products.Application.Requests;

namespace PhotoSi.Products.Application.RequestHandlers;
public class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest>
{
    private readonly IProductsRepository _productsRepository;

    public UpdateProductRequestHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        Product location = await _productsRepository.GetById(request.Id);

        if (location is null)
            throw new Exception("Invalid Product");

        location.Update(request.Name,
                        request.Category);

        await _productsRepository.UpdateAsync(location);
    }
}
