using Microsoft.Azure.Cosmos;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Models;

namespace WebAPI.Repository;

public class CosmosRepository<T> : IRepository<T> where T : Entity
{
    private readonly Container ContainerConnection;

    public CosmosRepository(CosmosConnectionManager connectionManager, string ContainerName)
    {
        ContainerConnection = connectionManager.CreateConnection(ContainerName);
    }
    
    public async Task<T> Get(string id)
    {
        return await ContainerConnection.FirstAsync<T>(id);
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
        entity.id = Guid.NewGuid().ToString();
        entity.CreatedDateTime = DateTime.UtcNow;
        return await ContainerConnection.CreateItemAsync(entity);
    }

    public async Task<ItemResponse<T>> Delete(string id)
    {
        var item = await ContainerConnection.FirstAsync<T>(id);

        if (item is null)
        {
            throw new Exception("Cannot delete this item");
        }
        return await ContainerConnection.DeleteItemAsync<T>(item.id, new PartitionKey(item.PartitionKey));
    }

 
    public async Task<ItemResponse<T>> Update(T entity)
    {
        return await ContainerConnection.UpsertItemAsync(entity, new PartitionKey(entity.PartitionKey));
    }
    
    public async Task<T> CheckUserCreds(UserInfo newUser)
    {
        return await ContainerConnection.CheckUsernameAndPassword<T>(newUser);
    }
}