using MediatR;

namespace PhotoSi.Orders.Application.Requests;
public class GetOrdersRequest : IRequest<IEnumerable<OrderDto>>
{
    public Guid? UserId { get; init; }

    public int PageNum { get; init; }

    public int PageSize { get; init; }
}
