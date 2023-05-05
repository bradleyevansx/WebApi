using System.ComponentModel;
using WebAPITest.Domain.Interfaces;

namespace WebAPITest.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public GenericCosmos<T> Connection;



    public Task<T> Get(string id, string partitionKey)
    {
        return Connection.Get(id, partitionKey);
    }

    public Task<IEnumerable<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Add(T entity)
    {
        return Connection.Add(entity);
    }

    public Task Delete(string id, string partitionKey)
    {
        return Connection.Delete(id, partitionKey);
    }

    public Task Update(string id, string partitionKey)
    {
        return Connection.Update(id, partitionKey);
    }
}