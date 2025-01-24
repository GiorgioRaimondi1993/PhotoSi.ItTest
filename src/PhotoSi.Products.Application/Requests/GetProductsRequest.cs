using MediatR;

namespace PhotoSi.Products.Application.Requests;
public class GetProductsRequest : IRequest<IEnumerable<ProductDto>>
{
    public string Category { get; init; }

    public int PageNum { get; init; }

    public int PageSize { get; init; }
}
