using WebAPITest.Domain.Models;

namespace WebAPITest.Domain.Interfaces;

public interface IPracticeSessionsRepository : IGenericRepository<PracticeSession>
{
    Task<IEnumerable<PracticeSession>> GetAllPracticeSessionsByUserId(string userId);
}