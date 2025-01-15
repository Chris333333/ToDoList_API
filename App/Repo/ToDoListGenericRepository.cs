using Data.Entities.ToDoListDatabase;
using Data.Interfaces;
using Data.Spec;
using Microsoft.EntityFrameworkCore;

namespace App.Repo
{
    public class ToDoListGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ToDoListContext _context;

        public ToDoListGenericRepository(ToDoListContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> ListAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
