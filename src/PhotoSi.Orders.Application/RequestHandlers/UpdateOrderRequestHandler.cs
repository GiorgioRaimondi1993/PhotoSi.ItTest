using MediatR;
using PhotoSi.Orders.Application.Models;
using PhotoSi.Orders.Application.Repositories;
using PhotoSi.Orders.Application.Requests;

namespace PhotoSi.Orders.Application.RequestHandlers;
public class UpdateOrderRequestHandler : IRequestHandler<UpdateOrderRequest>
{
    private readonly IOrdersRepository _orderRepository;

    public UpdateOrderRequestHandler(IOrdersRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
    {
        Order order = await _orderRepository.GetById(request.Id);

        if (order is null)
            throw new Exception("Invalid OrderId");

        order.Update(request.LocationId, request.Products);

        await _orderRepository.UpdateAsync(order);
    }
}
