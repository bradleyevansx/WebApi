using System.ComponentModel;
using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;

namespace WebAPITest.Repository;

public class GenericRepository<T> : IRepository<T> where T : class
{
    protected CosmosRepository<T> Connection;



    public Task<T> Get(string id, string partitionKey)
    {
        return Connection.Get(id, partitionKey);
    }

    public Task<IEnumerable<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<ItemResponse<T>> Add(T entity)
    {
        return Connection.Add(entity);
    }

    public Task<ItemResponse<T>> Delete(string id, string partitionKey)
    {
        return Connection.Delete(id, partitionKey);
    }

    public Task<ItemResponse<string?>> Update(string id, string partitionKey)
    {
        return Connection.Update(id, partitionKey);
    }
}