using cinemaApi.Database;
using cinemaApi.Models;
using cinemaApi.Repositories.BaseRepo;

namespace cinemaApi.Repositories.CinemaRepo
{
    public class CinemaRepo : BaseRepo<Cinema>, ICinemaRepo
    {
        public CinemaRepo(DataContext context) : base(context)
        {
        }
    }
}