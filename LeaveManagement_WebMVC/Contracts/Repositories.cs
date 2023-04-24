using LeaveManagement_WebMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement_WebMVC.Contracts
{
    public class Repositories<T> : IRepositories<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            //Chưa biết Class (1 bảng) nào nên Set tạm T là Class
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            var entity = await _context.Set<T>().ToListAsync();
            return entity;
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
