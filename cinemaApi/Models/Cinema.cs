namespace cinemaApi.Models
{
    public class Cinema : BaseModel
    {
        public string Name { get; set; } = null!;
        public int OpeningHour { get; set; }
        public int ClosingHour { get; set; }
        public int ShowDuration { get; set; }
    }
}