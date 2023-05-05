using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Repository;


public class PracticeSessionsRepository : GenericRepository<PracticeSession>, IPracticeSessionsRepository
{
    public PracticeSessionsRepository(Database containerId)
    {
        
        var container = containerId.GetContainer("Sessions");

        Connection = new GenericCosmos<PracticeSession>(container);
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