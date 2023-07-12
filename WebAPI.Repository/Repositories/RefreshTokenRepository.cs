using WebAPI.Domain.Models;

namespace WebAPI.Repository;

public class RefreshTokenRepository : CosmosRepository<RefreshToken>
{
    public RefreshTokenRepository(CosmosConnectionManager connectionManager) : base(connectionManager, "RefreshToken")
    {
    }
}