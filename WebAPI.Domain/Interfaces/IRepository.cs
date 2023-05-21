using Microsoft.Azure.Cosmos;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> Get(string id);
    Task<IEnumerable<T>> GetAll();
    Task<ItemResponse<T>> Add(T entity);
    Task<ItemResponse<T>> Delete(string id);
    Task<ItemResponse<T>> Update(T entity);
    
    Task<T> CheckUserCreds(UserInfo request);
}