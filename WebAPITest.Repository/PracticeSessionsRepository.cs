using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Repository;


public class PracticeSessionsRepository : IPracticeSessionsRepository
{
    public PracticeSessionsCosmos Connection;
    
    public PracticeSessionsRepository(PracticeSessionsCosmos connection)
    {
        Connection = connection;
    }
    
    
    public Task<PracticeSession> Get(PracticeSession entity)
    {
        return Connection.Get(entity);
    }

    public Task<IEnumerable<PracticeSession>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Add(PracticeSession entity)
    {
        return Connection.Add(entity);
    }

    public Task Delete(PracticeSession entity)
    {
        return Connection.Delete(entity);
    }

    public Task Update(PracticeSession entity)
    {
        return Connection.Update(entity);
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