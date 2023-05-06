using WebAPITest.Domain.Models;

namespace WebAPITest.Domain.Interfaces;

public interface IPracticeSessionsRepository : IRepository<PracticeSession>
{
    /*Task<IEnumerable<PracticeSession>> GetAllPracticeSessionsByUserId(string userId);*/
}