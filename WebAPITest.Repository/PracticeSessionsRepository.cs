using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Repository;

public class PracticeSessionsRepository : IPracticeSessionsRepository
{
    public Container _container;
    
    public PracticeSessionsRepository(Database database)
    {
        _container = database.GetContainer("Sessions");
    }
    
    
    
    public Task<PracticeSession> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PracticeSession>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Add(PracticeSession entity)
    {
        return _container.CreateItemAsync(entity);
    }

    public Task Delete(PracticeSession entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(PracticeSession entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PracticeSession>> GetAllPracticeSessionsByUserId(string userId)
    {
        var list = new List<PracticeSession>();
        
        var iterator = _container.GetItemQueryIterator<PracticeSession>($"select * from c where c.userId = '{userId}'");
        while (iterator.HasMoreResults)
        {
            list.AddRange(await iterator.ReadNextAsync());
        }
        return list;
    }
}