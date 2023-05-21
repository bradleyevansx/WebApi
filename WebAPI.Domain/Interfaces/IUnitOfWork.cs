using Microsoft.Azure.Cosmos;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<PracticeSession> PracticeSessionRepo { get; }
    IRepository<UserInfo> UserInfoRepo { get; }
}

