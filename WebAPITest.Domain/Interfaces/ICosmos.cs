using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Models;

namespace WebAPITest.Domain.Interfaces;

public interface ICosmos<T> where T : class
{
    Task<T> Get(T entity);
    Task<IEnumerable<T>> GetAll();
    Task<ItemResponse<T>> Add(T entity);
    Task<ItemResponse<T>> Delete(T entity);
    Task<ItemResponse<string?>> Update(T entity);
}