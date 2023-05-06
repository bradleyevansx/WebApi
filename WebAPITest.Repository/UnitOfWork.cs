using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Interfaces;

namespace WebAPITest.Repository;

public class UnitOfWork : IUnitOfWork
{
    public bool disposing = false;
    public IPracticeSessionRepository PracticeSessionRepo { get; }
    public IUserInfoRepository UserInfoRepo { get; }


    public UnitOfWork(IPracticeSessionRepository practiceSessionRepo, IUserInfoRepository userInfoRepo)
    {
        PracticeSessionRepo = practiceSessionRepo;
        UserInfoRepo = userInfoRepo;
    }

    public void Dispose() 
    { 
        Dispose(true); 
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            /*implement dispose if useful*/
        }
    }
}