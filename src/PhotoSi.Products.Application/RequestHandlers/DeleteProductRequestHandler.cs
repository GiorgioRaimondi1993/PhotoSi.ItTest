using MediatR;
using PhotoSi.Products.Application.Models;
using PhotoSi.Products.Application.Repositories;
using PhotoSi.Products.Application.Requests;

namespace PhotoSi.Products.Application.RequestHandlers;
public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest>
{
    private readonly IProductsRepository _productsRepository;

    public DeleteProductRequestHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        Product product = await _productsRepository.GetById(request.Id);

        if (product is null)
            return;

        await _productsRepository.DeleteAsync(product);
    }
}
