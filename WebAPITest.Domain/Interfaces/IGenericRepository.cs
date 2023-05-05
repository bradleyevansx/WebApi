namespace WebAPITest.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> Get(string id, string partitionKey);
    Task<IEnumerable<T>> GetAll();
    Task Add(T entity);
    Task Delete(string id, string partitionKey);
    Task Update(string id, string partitionKey);
}