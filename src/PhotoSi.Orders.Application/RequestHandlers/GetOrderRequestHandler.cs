using AutoMapper;
using MediatR;
using PhotoSi.Orders.Application.Models;
using PhotoSi.Orders.Application.Repositories;
using PhotoSi.Orders.Application.Requests;

namespace PhotoSi.Orders.Application.RequestHandlers;
public class GetOrderRequestHandler : IRequestHandler<GetOrderRequest, OrderDto>
{
    private readonly IMapper _mapper;
    private readonly IOrdersRepository _orderRepository;

    public GetOrderRequestHandler(IMapper mapper, IOrdersRepository orderRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public async Task<OrderDto> Handle(GetOrderRequest request, CancellationToken cancellationToken)
    {
        Order order = await _orderRepository.GetById(request.Id);

        return _mapper.Map<OrderDto>(order);
    }
}
