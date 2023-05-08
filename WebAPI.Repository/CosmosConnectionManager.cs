using Microsoft.Azure.Cosmos;

namespace WebAPITest.Repository;

public class CosmosConnectionManager : IDisposable
{
    private readonly CosmosClient ClientConnection;


    public CosmosConnectionManager()
    {
        ClientConnection = new CosmosClient("AccountEndpoint=https://obito-rip.documents.azure.com:443/;AccountKey=mZm47VxAmbhvNjRgT8CDx03kLmdMfotNW4gyptOfTB4Rl7kxBnzCwXTtcDjh6Cl8tgTuoI56HXKzACDb7QFGjw==;");
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