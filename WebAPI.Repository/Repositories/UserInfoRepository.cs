using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Repository;

public class UserInfoRepository : GenericRepository<UserInfo>
{

    public UserInfoRepository(CosmosConnectionManager connectionManager)
    {
        Connection = new CosmosRepository<UserInfo>(connectionManager,"UserInfo");
    }
    
    
    
    
}