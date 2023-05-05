using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Repository;

public class UserInfoRepository : IUserInfoRepository
{
    public UserInfoCosmos Connection;

    public UserInfoRepository(UserInfoCosmos connection)
    {
        Connection = connection;
    }
    
    public Task<UserInfo> Get(UserInfo entity)
    {
        return Connection.Get(entity);
    }

    public Task<IEnumerable<UserInfo>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Add(UserInfo entity)
    {
        return Connection.Add(entity);
    }
    /*public Task Add(UserInfo entity)
    {
        return _container.CreateItemAsync(entity);
    }*/

    public async Task Delete(UserInfo entity)
    {
        throw new NotImplementedException();
    }
    
    /*public async Task Delete(UserInfo entity)
    {
        var response = await _container.DeleteItemAsync<UserInfo>(entity.id, new PartitionKey(entity.id));
    }*/

    public Task Update(UserInfo entity)
    {
        throw new NotImplementedException();
    }
}