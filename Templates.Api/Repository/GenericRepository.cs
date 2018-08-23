using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Templates.Api.Domain;

namespace Templates.Api.Repository
{
    public abstract class GenericRepository<T> : IRepository<T>
      where T : class, new()
    {
        protected TemplatesDbContext _dbContext { get; set; }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public IQueryable<T> Query()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public async Task InsertAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}

