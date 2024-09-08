using ApplicationLayer.IGeneric;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using Restaurant_Table_Booking.Application.ISpecification;
using Restaurant_Table_Booking.Domain.SpecificationEntities;

namespace InfrastructureLayer.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AuthDbContext _authDbContext;
        public GenericRepository(AuthDbContext authDbContext)
        {
            _authDbContext = authDbContext;
        }

        public async Task CreateAsync(T entity) => await _authDbContext.Set<T>().AddAsync(entity);

        public IQueryable<T> GetAllAsync()
        {
            var bookings = _authDbContext.Set<T>();
            return bookings;
        }
        public Task DeleteAsync(T existngData)
        {
            _authDbContext.Set<T>().Remove(existngData);
            return Task.CompletedTask;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _authDbContext.Set<T>().FindAsync(id);

        }

        public Task UpdateAsync(T entity)
        {
            _authDbContext.Set<T>().Update(entity);
            return Task.CompletedTask;
        }

        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
       
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_authDbContext.Set<T>().AsQueryable(), spec);
        }
    }
}
