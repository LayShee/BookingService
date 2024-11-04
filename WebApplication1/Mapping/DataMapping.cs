using AutoMapper;
using BookingService.Dto;
using BookingService.Models;

namespace BookingService.Mapping
{
    public class DataMapping : Profile
    {
        public DataMapping()
        {
            CreateMap<Users, UserDto>();
            CreateMap<UserDto, Users>();
        }
    }
}
