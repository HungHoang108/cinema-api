using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cinemaApi.DTOs
{
    public class CinemaDto
    {
        public class CinemaBaseDto
        {
            public string Name { get; set; } = null!;
            public int OpeningHour { get; set; }
            public int ClosingHour { get; set; }
            public int ShowDuration { get; set; }
        }
        public class CinemaCreateDto : CinemaBaseDto
        {
        }
        public class CinemaReadDto : CinemaBaseDto
        {
            public int Id { get; set; }
        }
        public class CinemaUpdateDto : CinemaBaseDto
        {
        }
    }
}