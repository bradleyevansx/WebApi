using WebAPITest.Domain.Models;

namespace WebAPITest.Domain.Interfaces;

public interface IPracticeSessionRepository : IRepository<PracticeSession>
{
    /*Task<IEnumerable<PracticeSession>> GetAllPracticeSessionsByUserId(string userId);*/
}