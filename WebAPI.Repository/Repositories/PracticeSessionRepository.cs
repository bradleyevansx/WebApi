using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Repository;


public class PracticeSessionRepository : GenericRepository<PracticeSession>, IPracticeSessionRepository
{
    public PracticeSessionRepository(CosmosConnectionManager connectionManager)
    {
        Connection = new CosmosRepository<PracticeSession>(connectionManager, "Sessions");
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