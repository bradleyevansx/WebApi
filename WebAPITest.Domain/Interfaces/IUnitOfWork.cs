namespace WebAPITest.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IPracticeSessionRepository PracticeSessionRepo { get; }
    IUserInfoRepository UserInfoRepo { get; }
}

