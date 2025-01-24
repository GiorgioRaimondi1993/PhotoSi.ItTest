using MediatR;
using PhotoSi.Orders.Application.Models;
using PhotoSi.Orders.Application.Repositories;
using PhotoSi.Orders.Application.Requests;

namespace PhotoSi.Orders.Application.RequestHandlers;
public class CreateOrderRequestHandler : IRequestHandler<CreateOrderRequest, Guid>
{
    private readonly IOrdersRepository _orderRepository;

    public CreateOrderRequestHandler(IOrdersRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Guid> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        Order order = Order.Create(request.UserId, request.LocationId, request.Products);

        await _orderRepository.AddAsync(order);

        return order.Id;
    }
}
