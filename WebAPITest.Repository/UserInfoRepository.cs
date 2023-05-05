using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;
using WebAPITest.Domain.Models;

namespace WebAPITest.Repository;

public class UserInfoRepository : GenericRepository<UserInfo>, IUserInfoRepository
{

    public UserInfoRepository(Database containerId)
    {
        var container = containerId.GetContainer("UserInfo");

        Connection = new GenericCosmos<UserInfo>(container);
    }
    
    
    
}