using Microsoft.Azure.Cosmos;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Models;

namespace WebAPI.Repository;

public interface IUserInfoRepository : IRepository<UserInfo>
{
    Task<UserInfo?> GetByCredentialsAsync(string username, string password);
}

public class UserInfoRepository : CosmosRepository<UserInfo>, IUserInfoRepository
{
    public UserInfoRepository(CosmosConnectionManager connectionManager) : base(connectionManager, "UserInfo")
    {
    }

    public async Task<UserInfo?> GetByCredentialsAsync(string username, string password)
    {
        var results = await Query().Where(x => x.Username == username && x.Password == password).ToListAsync();
        if (results.Count is 0)
        {
            return null;
        }

        return results[0];
    }
}