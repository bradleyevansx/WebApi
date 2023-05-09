using System.ComponentModel;
using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Repository;

public class GenericRepository<T> : IRepository<T> where T : Entity
{
    protected CosmosRepository<T> Connection;



    public Task<T> Get(string id)
    {
        return Connection.Get(id);
    }

    public Task<IEnumerable<T>> GetAll()
    {
        return Connection.GetAll();
    }

    public Task<ItemResponse<T>> Add(T entity)
    {
        return Connection.Add(entity);
    }

    public Task<ItemResponse<T>> Delete(string id)
    {
        return Connection.Delete(id);
    }

    public Task<ItemResponse<T>> Update(T entity)
    {
        return Connection.Update(entity);
    }
}