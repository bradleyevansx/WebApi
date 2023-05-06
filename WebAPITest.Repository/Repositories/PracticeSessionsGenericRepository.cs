using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Repository;


public class PracticeSessionsGenericRepository : GenericRepository<PracticeSession>, IPracticeSessionsRepository
{
    public PracticeSessionsGenericRepository()
    {
        Connection = new CosmosRepository<PracticeSession>("Sessions");
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