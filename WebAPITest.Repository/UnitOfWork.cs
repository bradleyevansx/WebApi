using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;

namespace WebAPITest.Repository;

public class UnitOfWork : IUnitOfWork
{
    public IPracticeSessionRepository PracticeSession { get; }
    public IUserInfoRepository UserInfo { get; }


    public UnitOfWork(IPracticeSessionRepository practiceSession, IUserInfoRepository userInfoRepository)
    {
        PracticeSession = practiceSession;
        UserInfo = userInfoRepository;
    }
    
    public void Dispose()
    {
    }

}