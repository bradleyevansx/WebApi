using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Repository;

public class GenericCosmos<T> : ICosmos<T> where T : class
{
    private readonly Container _container;

    public GenericCosmos(Container containerId)
    {
        _container = containerId;
    }
    
    public async Task<T> Get(string id, string partitionKey)
    {
        return await _container.ReadItemAsync<T>(id, new PartitionKey(partitionKey));
    }

    public Task<IEnumerable<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<ItemResponse<T>> Add(T entity)
    {
        
        return await _container.CreateItemAsync(entity);
    }

    public async Task<ItemResponse<T>> Delete(string id, string partitionKey)
    {
        return await _container.DeleteItemAsync<T>(id, new PartitionKey(partitionKey));
    }

    public async Task<ItemResponse<string?>> Update(string id, string partitionKey)
    {
        return await _container.UpsertItemAsync(id, new PartitionKey(partitionKey));
    }
}