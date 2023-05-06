using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Repository;

public class CosmosRepository<T> : IRepository<T> where T : class
{
    private readonly Container ContainerConnection;

    public CosmosRepository(CosmosConnectionManager connectionManager, string ContainerName)
    {
        ContainerConnection = connectionManager.CreateConnection(ContainerName);
    }
    
    public async Task<T> Get(string id, string partitionKey)
    {
        return await ContainerConnection.ReadItemAsync<T>(id, new PartitionKey(partitionKey));
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        var documents = ContainerConnection.GetItemQueryIterator<T>("SELECT * FROM c");
        var results = new List<T>();
        while (documents.HasMoreResults)
        {
            var response = await documents.ReadNextAsync();
            results = response.ToList();
        }

        return results;
    }

    public async Task<ItemResponse<T>> Add(T entity)
    {
        
        return await ContainerConnection.CreateItemAsync(entity);
    }

    public async Task<ItemResponse<T>> Delete(string id, string partitionKey)
    {
        return await ContainerConnection.DeleteItemAsync<T>(id, new PartitionKey(partitionKey));
    }

 
    public async Task<ItemResponse<T>> Update(T entity, string partitionKey)
    {
        return await ContainerConnection.UpsertItemAsync(entity, new PartitionKey(partitionKey));
    }
}