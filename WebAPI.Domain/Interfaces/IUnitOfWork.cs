using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Models;

namespace WebAPITest.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<PracticeSession> PracticeSessionRepo { get; }
    IRepository<UserInfo> UserInfoRepo { get; }
}

