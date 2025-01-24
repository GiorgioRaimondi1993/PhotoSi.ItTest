using AutoMapper;
using MediatR;
using PhotoSi.Products.Application.Models;
using PhotoSi.Products.Application.Repositories;
using PhotoSi.Products.Application.Requests;

namespace PhotoSi.Products.Application.RequestHandlers;
public class GetProductsRequestHandler : IRequestHandler<GetProductsRequest, IEnumerable<ProductDto>>
{
    private readonly IMapper _mapper;
    private readonly IProductsRepository _productsRepository;

    public GetProductsRequestHandler(IMapper mapper, IProductsRepository productsRepository)
    {
        _mapper = mapper;
        _productsRepository = productsRepository;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> products = await _productsRepository.GetListAsync(request.Category,
                                                                               request.PageNum,
                                                                               request.PageSize);

        return products.Select(o => _mapper.Map<ProductDto>(o));
    }
}
