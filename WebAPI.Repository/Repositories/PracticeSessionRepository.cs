using Microsoft.Azure.Cosmos;
using WebAPI.Domain.Models;

namespace WebAPI.Repository;

public class PracticeSessionRepository : CosmosRepository<PracticeSession>
{
    public PracticeSessionRepository(CosmosConnectionManager connectionManager) : base(connectionManager, "Sessions")
    {
        
    }
    
    
    

    /*public async Task<IEnumerable<PracticeSession>> GetAllPracticeSessionsByUserId(string userId)
    {
        var list = new List<PracticeSession>();
        
        var iterator = _container.GetItemQueryIterator<PracticeSession>($"select * from c where c.userId = '{userId}'");
        while (iterator.HasMoreResults)
        {
            list.AddRange(await iterator.ReadNextAsync());
        }
        return list;
    }*/
}