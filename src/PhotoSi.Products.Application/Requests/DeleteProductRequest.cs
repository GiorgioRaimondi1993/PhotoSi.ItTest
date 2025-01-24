using MediatR;

namespace PhotoSi.Products.Application.Requests;
public class DeleteProductRequest : IRequest
{
    public Guid Id { get; init; }
}
