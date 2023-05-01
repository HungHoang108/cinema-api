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
        public async Task<ActionResult<IEnumerable<Tuple<int, int>>>> GetShowTimes([FromRoute] int id, int open, int close, int length)
        {
            var cinema = await _context.Cinemas.FindAsync(id);

            if (cinema == null) throw ServiceException.NotFound();

            //if the closing hour is after 24, then it's added by 24 to keep the while loop runnning
            //For example closing hour is for example 3am and opening hour is 16, the while loop will keep running as long as opening hour < closing hour
            int closingHour = close;
            if (close < 12) closingHour += 24;

            int startHour = open;
            int startMinute = 0;

            //hourCount is used to compare with closingHour starting from openning hour until it's ,
            //each hour passed will be increased by one
            int hourCount = open;

            var showtimes = new List<Tuple<int, int>>();
            showtimes.Add(new Tuple<int, int>(startHour, startMinute));

            while (hourCount < closingHour)
            {

                //total number of minutes to calculate the next starting time of a movie
                int minutes = startMinute + length + 15;
                if (minutes > 60)
                {
                    int remainder = minutes % 60;
                    startMinute = remainder;
                    if (remainder == 0)
                    {
                        startHour += minutes / 60;
                        hourCount += minutes / 60;
                    }
                    else
                    {
                        startHour += (minutes - remainder) / 60;
                        hourCount += (minutes - remainder) / 60;

                    }
                    if (startHour > 24) startHour -= 24;

                    //Calculate movie ending time
                    var movieEndingHour = CalculateMovieEndingTime(hourCount, startMinute, length);
                    if (movieEndingHour >= closingHour) break;
                    showtimes.Add(new Tuple<int, int>(startHour, startMinute));
                }
                else
                {
                    startMinute = minutes;
                    showtimes.Add(new Tuple<int, int>(startHour, startMinute));
                }
            }
            return showtimes;
        }
        private int CalculateMovieEndingTime(int hourCount, int startMinute, int length)
        {
            int movieDurationAndStartMinute = length + startMinute;

            int endingRemainder = movieDurationAndStartMinute % 60;
            if (endingRemainder == 0)
            {
                return hourCount + (movieDurationAndStartMinute / 60);
            }
            else
            {
                return hourCount + ((movieDurationAndStartMinute - endingRemainder) / 60);
            }
        }
    }
}