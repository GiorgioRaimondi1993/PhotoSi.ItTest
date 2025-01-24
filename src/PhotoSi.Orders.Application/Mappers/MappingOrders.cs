using AutoMapper;
using PhotoSi.Orders.Application.Models;
using PhotoSi.Orders.Application.Requests;

namespace PhotoSi.Orders.Application.Mappers;

public class MappingOrders : Profile
{
    public MappingOrders()
    {
        CreateMap<Order, OrderDto>();
    }
}
