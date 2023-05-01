using cinemaApi.Repositories.BaseRepo;
using AutoMapper;
using cinemaApi.Helpers;

namespace cinemaApi.Services
{
    public class BaseService<T, TCreateDto, TReadDto, TUpdateDto> : IBaseService<T, TCreateDto, TReadDto, TUpdateDto>
    {
        protected readonly IMapper _mapper;
        protected readonly IBaseRepo<T> _repo;

        public BaseService(IMapper mapper, IBaseRepo<T> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<TReadDto> CreateAsync(TCreateDto create)
        {
            var entity = _mapper.Map<T>(create);
            var result = await _repo.CreateAsync(entity) ?? throw ServiceException.CreationError();
            return _mapper.Map<TReadDto>(result);
        }

        public async Task<TReadDto?> GetAsync(int id)
        {
            var result = await _repo.GetAsync(id);
            if (result == null)
            {
                throw ServiceException.NotFound();
            }
            return _mapper.Map<TReadDto>(result);
        }

        public async Task<ICollection<TReadDto>> GetAllAsync(QueryOptions options)
        {
            var result = await _repo.GetAllAsync(options);
            return _mapper.Map<ICollection<TReadDto>>(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetAsync(id);
            if (item is null)
            {
                return false;
            }
            var result = await _repo.DeleteAsync(id);
            return result;
        }

        public async Task<TReadDto> UpdateAsync(int id, TUpdateDto update)
        {
            var item = await GetAsync(id);
            if (item is null)
            {
                throw ServiceException.NotFound();
            }
            var updateData = _mapper.Map<T>(update);
            var result = await _repo.UpdateAsync(id, updateData);

            return _mapper.Map<TReadDto>(result);
        }
    }
}