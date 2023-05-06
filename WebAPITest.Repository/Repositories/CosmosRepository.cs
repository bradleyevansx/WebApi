using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Repository;

public class CosmosRepository<T> : IRepository<T> where T : class
{
    private readonly Container ContainerConnection;

    public CosmosRepository(CosmosConnectionManager connectionManager, string containerName)
    {
        ContainerConnection = connectionManager.CreateConnection(containerName);
    }
    
    public async Task<T> Get(string id, string partitionKey)
    {
        return await ContainerConnection.ReadItemAsync<T>(id, new PartitionKey(partitionKey));
    }

    public Task<IEnumerable<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<ItemResponse<T>> Add(T entity)
    {
        
        return await ContainerConnection.CreateItemAsync(entity);
    }

    public async Task<ItemResponse<T>> Delete(string id, string partitionKey)
    {
        return await ContainerConnection.DeleteItemAsync<T>(id, new PartitionKey(partitionKey));
    }

    public async Task<ItemResponse<string?>> Update(string id, string partitionKey)
    {
        return await ContainerConnection.UpsertItemAsync(id, new PartitionKey(partitionKey));
    }
}