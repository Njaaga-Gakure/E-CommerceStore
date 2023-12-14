using AutoMapper;
using E_CommerceStore.Models;
using E_CommerceStore.Models.DTOS;

namespace E_CommerceStore.Profiles
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<AddProductDTO, Product>().ReverseMap();   
            CreateMap<AddOrderDTO, Order>().ReverseMap();   
        }
    }
}
