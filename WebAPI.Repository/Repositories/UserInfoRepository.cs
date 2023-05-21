using Microsoft.Azure.Cosmos;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Models;

namespace WebAPI.Repository;

public class UserInfoRepository : GenericRepository<UserInfo>
{

    public UserInfoRepository(CosmosConnectionManager connectionManager)
    {
        Connection = new CosmosRepository<UserInfo>(connectionManager,"UserInfo");
    }
    
    
    
    
}