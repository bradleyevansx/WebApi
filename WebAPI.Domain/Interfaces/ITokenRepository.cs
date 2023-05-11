using WebAPITest.Domain.Models;

namespace WebAPITest.Domain.Interfaces;

public interface ITokenRepository
{
    string CreateToken(UserInfo user);
}