using AutoMapper;
using MediatR;
using PhotoSi.Orders.Application.Models;
using PhotoSi.Orders.Application.Repositories;
using PhotoSi.Orders.Application.Requests;

namespace PhotoSi.Orders.Application.RequestHandlers;
public class GetOrdersRequestHandler : IRequestHandler<GetOrdersRequest, IEnumerable<OrderDto>>
{
    private readonly IMapper _mapper;
    private readonly IOrdersRepository _ordersRepository;

    public GetOrdersRequestHandler(IMapper mapper, IOrdersRepository ordersRepository)
    {
        _mapper = mapper;
        _ordersRepository = ordersRepository;
    }

    public async Task<IEnumerable<OrderDto>> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Order> orders = await _ordersRepository.GetListAsync(request.UserId,
                                                                         request.PageNum,
                                                                         request.PageSize);

        return orders.Select(o => _mapper.Map<OrderDto>(o));
    }
}
