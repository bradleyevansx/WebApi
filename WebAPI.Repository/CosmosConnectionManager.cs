using Microsoft.Azure.Cosmos;

namespace WebAPI.Repository;

public class CosmosConnectionManager : IDisposable
{
    private readonly CosmosClient ClientConnection;


    public CosmosConnectionManager()
    {
        ClientConnection = new CosmosClient(string ConnectionString);
    }

    public Container CreateConnection(string containerId)
    {
        return ClientConnection.GetContainer("Music", containerId);
    }



 
    public void Dispose()
    {
        ClientConnection.Dispose();
    }
    
    
}
