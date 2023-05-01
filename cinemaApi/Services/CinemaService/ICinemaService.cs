using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cinemaApi.Models;
using static cinemaApi.DTOs.CinemaDto;

namespace cinemaApi.Services.CinemaService
{
    public interface ICinemaService : IBaseService<Cinema, CinemaCreateDto, CinemaReadDto, CinemaUpdateDto>
    {
    }
}