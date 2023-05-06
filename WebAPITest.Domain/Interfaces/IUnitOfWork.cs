namespace WebAPITest.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IPracticeSessionRepository PracticeSession { get; }
    IUserInfoRepository UserInfo { get; }
}

