using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;

namespace WebAPITest.Repository;

public class UnitOfWork : IUnitOfWork
{
    public IPracticeSessionsRepository PracticeSessions { get; }
    public IUserInfoRepository UserInfo { get; }


    public UnitOfWork(IPracticeSessionsRepository practiceSessions, IUserInfoRepository userInfoRepository)
    {
        PracticeSessions = practiceSessions;
        UserInfo = userInfoRepository;
    }
    
    public void Dispose()
    {
    }

}