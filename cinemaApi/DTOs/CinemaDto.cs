
using System.ComponentModel.DataAnnotations;

namespace cinemaApi.DTOs
{
    public class CinemaDto
    {
        public class CinemaBaseDto
        {
            public string Name { get; set; } = null!;

            [Range(12, 23, ErrorMessage = "The opening hour must be between 12 and 23.")]
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