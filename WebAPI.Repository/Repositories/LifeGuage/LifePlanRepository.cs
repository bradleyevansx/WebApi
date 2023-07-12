using Models;

namespace WebAPI.Repository.LifeGuage;

public class LifePlanRepository : CosmosRepository<LifePlan>
{
    public LifePlanRepository(CosmosConnectionManager connectionManager) : base(connectionManager, "LifePlans")
    {
        
    }
}