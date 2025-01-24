using MediatR;
using PhotoSi.Orders.Application.Models;
using PhotoSi.Orders.Application.Repositories;
using PhotoSi.Orders.Application.Requests;

namespace PhotoSi.Orders.Application.RequestHandlers;
public class DeleteOrderRequestHandler : IRequestHandler<DeleteOrderRequest>
{
    private readonly IOrdersRepository _orderRepository;

    public DeleteOrderRequestHandler(IOrdersRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
    {
        Order order = await _orderRepository.GetById(request.OrderId);

        if (order is null)
            return;

        await _orderRepository.DeleteAsync(order);
    }
}
