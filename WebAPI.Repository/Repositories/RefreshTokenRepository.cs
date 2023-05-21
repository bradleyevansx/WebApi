using WebAPI.Domain.Models;

namespace WebAPI.Repository;

public class RefreshTokenRepository : GenericRepository<RefreshToken>
{
    public RefreshTokenRepository(CosmosConnectionManager connectionManager)
    {
        Connection = new CosmosRepository<RefreshToken>(connectionManager, "RefreshToken");
    }
}