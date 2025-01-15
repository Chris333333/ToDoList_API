namespace Data.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int Id);
        Task<List<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<List<T>> ListAllWithSpecAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}
