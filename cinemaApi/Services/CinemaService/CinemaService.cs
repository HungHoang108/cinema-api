using AutoMapper;
using cinemaApi.Models;
using cinemaApi.Repositories.BaseRepo;
using static cinemaApi.DTOs.CinemaDto;

namespace cinemaApi.Services.CinemaService
{
    public class CinemaService : BaseService<Cinema, CinemaCreateDto, CinemaReadDto, CinemaUpdateDto>, ICinemaService
    {
        public CinemaService(IMapper mapper, IBaseRepo<Cinema> repo) : base(mapper, repo)
        {
        }
    }
}