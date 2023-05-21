using Microsoft.Azure.Cosmos;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Models;

namespace WebAPI.Repository;

public class UnitOfWork : IUnitOfWork
{
    public bool disposing = false;
    public IRepository<PracticeSession> PracticeSessionRepo { get; }
    public IRepository<UserInfo> UserInfoRepo { get; }


    public UnitOfWork(IRepository<PracticeSession> practiceSessionRepo, IRepository<UserInfo> userInfoRepo)
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