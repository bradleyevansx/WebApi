using WebAPITest.Domain.Models;

namespace WebAPITest.Repository;

public class RefreshTokenRepository : GenericRepository<RefreshToken>
{
    public RefreshTokenRepository(CosmosConnectionManager connectionManager)
    {
        Connection = new CosmosRepository<RefreshToken>(connectionManager, "RefreshToken");
    }
}