using cinemaApi.Repositories.BaseRepo;

namespace cinemaApi.Services
{
        public interface IBaseService<T, TCreateDto, TReadDto, TUpdateDto>
        {
            Task<TReadDto> CreateAsync(TCreateDto create);
            Task<TReadDto?> GetAsync(int id);
            Task<ICollection<TReadDto>> GetAllAsync(QueryOptions options);
            Task<TReadDto> UpdateAsync(int id, TUpdateDto update);
            Task<bool> DeleteAsync(int id);
        }
    
}