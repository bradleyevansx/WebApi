using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Repository;

public class PracticeSessionsCosmos : ICosmos<PracticeSession>
{
    private readonly Container _container;

    public PracticeSessionsCosmos()
    {
        var client =
            new CosmosClient(
                "AccountEndpoint=https://obito-rip.documents.azure.com:443/;AccountKey=mZm47VxAmbhvNjRgT8CDx03kLmdMfotNW4gyptOfTB4Rl7kxBnzCwXTtcDjh6Cl8tgTuoI56HXKzACDb7QFGjw==;");
        
        
        _container = client.GetContainer("Music","Sessions");
    }


    public async Task<PracticeSession> Get(PracticeSession entity)
    {
        return await _container.ReadItemAsync<PracticeSession>(entity.id, new PartitionKey(entity.id));
    }

    public Task<IEnumerable<PracticeSession>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<ItemResponse<PracticeSession>> Add(PracticeSession entity)
    {
        return await _container.CreateItemAsync(entity);
    }

    public async Task<ItemResponse<PracticeSession>> Delete(PracticeSession entity)
    {
        return await _container.DeleteItemAsync<PracticeSession>(entity.id, new PartitionKey(entity.userId));
    }

    public async Task<ItemResponse<string?>> Update(PracticeSession entity)
    {
        return await _container.UpsertItemAsync(entity.id, new PartitionKey(entity.userId));
    }
}