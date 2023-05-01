namespace cinemaApi.Repositories.BaseRepo
{
    public interface IBaseRepo<T>
    {
        Task<T> CreateAsync(T request);
        Task<T?> GetAsync(int id);

        //Using IEnumerable should be enough in case of only reading the data
        Task<ICollection<T>> GetAllAsync(QueryOptions options);
        Task<T> UpdateAsync(int id, T request);
        Task<bool> DeleteAsync(int id);
    }
    public class QueryOptions
    {
        public string Sort { get; set; } = string.Empty;
        public string Search { get; set; } = string.Empty;
        public SortBy SortBy { get; set; }
        public int Limit { get; set; } = 30;
        public int Skip { get; set; } = 0;
    }

    public enum SortBy
    {
        ASC,
        DESC
    }
}