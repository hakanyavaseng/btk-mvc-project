using AutoMapper;
using Entities.DTOs.Product;
using Entities.Models;

namespace StoreApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>().ReverseMap();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
        }
    }
}
