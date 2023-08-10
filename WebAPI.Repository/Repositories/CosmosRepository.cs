using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Models;

namespace WebAPI.Repository;

public class CosmosRepository<T> : IRepository<T> where T : Entity
{
    private readonly Container _containerConnection;

    public CosmosRepository(CosmosConnectionManager connectionManager, string containerName)
    {
        _containerConnection = connectionManager.CreateConnection(containerName);
    }
    
    public async Task<T?> GetAsync(string id)
    {
        return await _containerConnection.FirstAsync<T>(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var documents = _containerConnection.GetItemQueryIterator<T>("SELECT * FROM c");
        var results = new List<T>();
        while (documents.HasMoreResults)
        {
            var response = await documents.ReadNextAsync();
            results = response.ToList();
        }

        return results;
    }

    public IOrderedQueryable<T> Query()
    {
        return _containerConnection.GetItemLinqQueryable<T>();
    }

    public async Task<ItemResponse<T>> CreateAsync(T entity)
    {
        entity.id = Guid.NewGuid().ToString();
        entity.CreatedDateTime = DateTime.UtcNow;
        return await _containerConnection.CreateItemAsync(entity);
    }

    public async Task<ItemResponse<T>?> DeleteAsync(string id)
    {
        var item = await _containerConnection.FirstAsync<T>(id);

        if (item is null)
        {
            return null;
        }
        return await _containerConnection.DeleteItemAsync<T>(item.id, new PartitionKey(item.PartitionKey));
    }

 
    public async Task<ItemResponse<T>> UpdateAsync(T entity)
    {
        return await _containerConnection.UpsertItemAsync(entity, new PartitionKey(entity.PartitionKey));
    }
    
}