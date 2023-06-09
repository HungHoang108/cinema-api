using AutoMapper;
using cinemaApi.Models;
using static cinemaApi.DTOs.CinemaDto;

namespace cinemaApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cinema, CinemaReadDto>().ReverseMap();
            CreateMap<CinemaCreateDto, Cinema>();
            CreateMap<CinemaUpdateDto, Cinema>();
        }
    }
}