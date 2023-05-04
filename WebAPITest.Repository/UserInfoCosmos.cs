using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Repository;

public class UserInfoCosmos : ICosmos<UserInfo>
{
    private readonly Container _container;

    public UserInfoCosmos()
    {
        var client =
            new CosmosClient(
                "AccountEndpoint=https://obito-rip.documents.azure.com:443/;AccountKey=mZm47VxAmbhvNjRgT8CDx03kLmdMfotNW4gyptOfTB4Rl7kxBnzCwXTtcDjh6Cl8tgTuoI56HXKzACDb7QFGjw==;");
        
        
        _container = client.GetContainer("Music","UserInfo");
    }
    
    public async Task<UserInfo> Get(UserInfo entity)
    {
        return await _container.ReadItemAsync<UserInfo>(entity.id, new PartitionKey(entity.id));
    }

    public Task<IEnumerable<UserInfo>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<ItemResponse<UserInfo>> Add(UserInfo entity)
    {
        return await _container.CreateItemAsync(entity);
    }

    public async Task<ItemResponse<UserInfo>> Delete(UserInfo entity)
    {
        return await _container.DeleteItemAsync<UserInfo>(entity.id, new PartitionKey(entity.id));
    }

    public async Task<ItemResponse<string?>> Update(UserInfo entity)
    {
        return await _container.UpsertItemAsync(entity.id, new PartitionKey(entity.id));
    }
}