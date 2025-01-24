using AutoMapper;
using MediatR;
using PhotoSi.Products.Application.Models;
using PhotoSi.Products.Application.Repositories;
using PhotoSi.Products.Application.Requests;

namespace PhotoSi.Products.Application.RequestHandlers;
public class GetProductRequestHandler : IRequestHandler<GetProductRequest, ProductDto>
{
    private readonly IMapper _mapper;
    private readonly IProductsRepository _productsRepository;

    public GetProductRequestHandler(IMapper mapper, IProductsRepository productsRepository)
    {
        _mapper = mapper;
        _productsRepository = productsRepository;
    }

    public async Task<ProductDto> Handle(GetProductRequest request, CancellationToken cancellationToken)
    {
        Product product = await _productsRepository.GetById(request.Id);

        return _mapper.Map<ProductDto>(product);
    }
}
