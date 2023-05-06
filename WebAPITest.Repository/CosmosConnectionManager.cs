using Microsoft.Azure.Cosmos;

namespace WebAPITest.Repository;

public class CosmosConnectionManager
{
    private readonly CosmosClient ClientConnection;
    public Container ContainerConnection;

    public CosmosConnectionManager(string containerName)
    {
        ClientConnection = new CosmosClient("AccountEndpoint=https://obito-rip.documents.azure.com:443/;AccountKey=mZm47VxAmbhvNjRgT8CDx03kLmdMfotNW4gyptOfTB4Rl7kxBnzCwXTtcDjh6Cl8tgTuoI56HXKzACDb7QFGjw==;");
        ContainerConnection = ClientConnection.GetContainer("Music", containerName);
    }

    
}