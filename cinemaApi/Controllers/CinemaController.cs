using cinemaApi.Database;
using cinemaApi.Helpers;
using cinemaApi.Models;
using cinemaApi.Services.CinemaService;
using Microsoft.AspNetCore.Mvc;
using static cinemaApi.DTOs.CinemaDto;


namespace cinemaApi.Controllers
{
    public class CinemaController : BaseController<Cinema, CinemaCreateDto, CinemaReadDto, CinemaUpdateDto>
    {
        protected readonly DataContext _context;
        public CinemaController(DataContext context, ICinemaService service) : base(service)
        {
            _context = context;
        }

        [HttpGet("{id:int}/showtimes")]
        //another return type option is Task<ActionResult<IEnumerable<Tuple<int, int>>>>, then response will be an array of object of hour and minute
        public async Task<ActionResult<IEnumerable<string>>> GetShowTimes([FromRoute] int id, int open, int close, int length)
        {

            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema == null) throw ServiceException.NotFound();

            var openingHourInMinutes = open * 60;
            //if closing hour is after 24, then add it by 24 to convert into minutes
            var closingHour = close;
            if (close <= 6) closingHour += 24;
            var closingTimeInMinutes = closingHour * 60;

            int movieStartHour = 0;
            int movieStartMinute = 0;
            var showtimes = new List<string>();

            for (var i = openingHourInMinutes; i < closingTimeInMinutes; i += (length + 15))
            {
                int movieEndingTimeInMinute = 0;
                int remainder = i % 60;
                movieStartHour = (i - remainder) / 60;
                if (movieStartHour > 24) movieStartHour -= 24;

                movieStartMinute = remainder;
                var result = $"({movieStartHour.ToString()}, {movieStartMinute.ToString()})";

                //if the movie ends after the cinema is closed then break to stop Add() to add new starting time
                movieEndingTimeInMinute = i + length;
                if (movieEndingTimeInMinute >= closingTimeInMinutes) break;

                showtimes.Add(result);
            }
            return showtimes;
        }
    }
}