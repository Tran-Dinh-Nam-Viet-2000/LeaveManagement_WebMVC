namespace LeaveManagement_WebMVC.Contracts
{
    public interface IRepositories<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetById(int id);
        Task Delete(int id);
    }
}
