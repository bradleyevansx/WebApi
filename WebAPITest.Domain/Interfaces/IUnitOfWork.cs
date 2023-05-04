namespace WebAPITest.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IPracticeSessionsRepository PracticeSessions { get; }
    IUserInfoRepository UserInfo { get; }
}

