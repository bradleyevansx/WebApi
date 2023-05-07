using Microsoft.Azure.Cosmos;

namespace WebAPITest.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> Get(string id, string partitionKey);
    Task<IEnumerable<T>> GetAll();
    Task<ItemResponse<T>> Add(T entity);
    Task<ItemResponse<T>> Delete(string id, string partitionKey);
    Task<ItemResponse<T>> Update(T entity, string partitionKey);
}