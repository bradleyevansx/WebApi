namespace WebAPITest.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> Get(int id);
    Task<IEnumerable<T>> GetAll();
    Task Add(T entity);
    Task Delete(T entity);
    Task Update(T entity);
}