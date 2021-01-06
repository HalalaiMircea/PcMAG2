using AutoMapper;
using PcMAG2.Models.DTOs;
using PcMAG2.Models.Entities;

namespace PcMAG2.Models.Mappings
{
    public class CartMappingProfile : Profile
    {
        public CartMappingProfile()
        {
            CreateMap<CartItemDTO, CartItem>();
        }
    }
}