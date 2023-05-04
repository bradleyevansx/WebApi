using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;

namespace WebAPITest.Repository;

public class UnitOfWork : IUnitOfWork
{
    public Database unitOfWorkDatabase;
    
    public IPracticeSessionsRepository PracticeSessions { get; }
    public IUserInfoRepository UserInfo { get; }


    public UnitOfWork(Database database, IPracticeSessionsRepository practiceSessions, IUserInfoRepository userInfoRepository)
    {
        unitOfWorkDatabase = database;
        PracticeSessions = practiceSessions;
        UserInfo = userInfoRepository;
    }
    
    public void Dispose()
    {
    }

}