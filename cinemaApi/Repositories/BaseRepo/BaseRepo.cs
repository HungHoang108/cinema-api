
using cinemaApi.Database;
using cinemaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace cinemaApi.Repositories.BaseRepo
{
    public class BaseRepo<T> : IBaseRepo<T>
        where T : BaseModel
    {
        protected readonly DataContext _context;

        public BaseRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T request)
        {
            await _context.Set<T>().AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<T?> GetAsync(int id)
        {
            var item = await _context.Set<T>().FindAsync(id);
            return item;
        }
        //This method will be overridden later for sorting purpose, which is suitable to each Model
        public virtual async Task<ICollection<T>> GetAllAsync(QueryOptions options)
        {
            var itemList = _context.Set<T>().AsNoTracking();
            itemList.Skip(options.Skip).Take(options.Limit);
            return await itemList.ToArrayAsync();
        }

        public async Task<T> UpdateAsync(int id, T request)
        {
            var item = await GetAsync(id);
            request.Id = item!.Id;
            _context.Entry(item).CurrentValues.SetValues(request);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity!);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}