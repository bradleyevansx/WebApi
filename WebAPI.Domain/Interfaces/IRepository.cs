using Microsoft.Azure.Cosmos;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<ItemResponse<T>> CreateAsync(T entity);
    Task<ItemResponse<T>?> DeleteAsync(string id);
    Task<ItemResponse<T>> UpdateAsync(T entity);
    public IOrderedQueryable<T> Query();

}