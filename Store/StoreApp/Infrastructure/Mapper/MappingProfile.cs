using AutoMapper;
using Entities.DTOs.Account;
using Entities.DTOs.Product;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace StoreApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>().ReverseMap();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
            CreateMap<ProductListIndexDto, Product>().ReverseMap();
            CreateMap<UserDtoForCreation,IdentityUser>().ReverseMap();
        }
    }
}
