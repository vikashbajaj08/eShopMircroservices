using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Domain.Entities;

namespace Catalog.Application.MappingProfile
{
    public class ProductMappingProfile :Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<ProductDto, Product>();
        }
    }
}
