using MediatR;

namespace PhotoSi.Orders.Application.Requests;
public class DeleteOrderRequest : IRequest
{
    public Guid OrderId { get; init; }
}
