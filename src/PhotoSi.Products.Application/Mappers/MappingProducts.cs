using AutoMapper;
using PhotoSi.Products.Application.Models;
using PhotoSi.Products.Application.Requests;

namespace PhotoSi.Products.Application.Mappers;
public class MappingProducts : Profile
{
    public MappingProducts()
    {
        CreateMap<Product, ProductDto>();
    }
}
