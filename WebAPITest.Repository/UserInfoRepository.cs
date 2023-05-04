using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Repository;

public class UserInfoRepository : IUserInfoRepository
{
    public Container _container;

    public UserInfoRepository(Database database)
    {
        _container = database.GetContainer("UserInfo");
    }
    
    public Task<UserInfo> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserInfo>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Add(UserInfo entity)
    {
        return _container.CreateItemAsync(entity);
    }

    public async Task Delete(UserInfo entity)
    {
        var response = await _container.DeleteItemAsync<UserInfo>(entity.id, new PartitionKey(entity.id));
    }

    public Task Update(UserInfo entity)
    {
        throw new NotImplementedException();
    }
}