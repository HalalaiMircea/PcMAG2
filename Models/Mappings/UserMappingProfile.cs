using AutoMapper;
using PcMAG2.Models.DTOs;
using PcMAG2.Models.Entities;

namespace PcMAG2.Models.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterRequest, User>();
            CreateMap<User, AuthResponse>();
        }
    }
}