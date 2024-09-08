using Restaurant_Table_Booking.Application.ISpecification;

namespace ApplicationLayer.IGeneric
{
    public interface IGenericRepository<T> where T : class 
    {
        //IQueryable<T> GetAllAsync();
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<T?> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T existngData);

    }
}
