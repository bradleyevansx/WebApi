using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Repository;

public class UserInfoGenericRepository : GenericRepository<UserInfo>, IUserInfoRepository
{

    public UserInfoGenericRepository()
    {
        Connection = new CosmosRepository<UserInfo>("UserInfo");
    }
    
    
    
}