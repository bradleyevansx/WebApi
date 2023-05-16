using WebAPITest.Domain.Models;

namespace WebAPITest.Domain.Interfaces;

public interface ITokenRepository
{
    public Task<AuthenticationResponse> CreateAuthenticationResponseAsync(UserInfo userInfo);
    public Task<AuthenticationResponse> CreateAuthenticationResponseAsync(string refreshTokenId);
}