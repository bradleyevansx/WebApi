using Microsoft.Azure.Cosmos;

namespace WebAPI.Repository;

public class CosmosConnectionManager
{
    private readonly CosmosClient ClientConnection;


    public CosmosConnectionManager()
    {
        ClientConnection = new CosmosClient("https://obito-rip.documents.azure.com:443/", "mZm47VxAmbhvNjRgT8CDx03kLmdMfotNW4gyptOfTB4Rl7kxBnzCwXTtcDjh6Cl8tgTuoI56HXKzACDb7QFGjw==");
    }

    public Container CreateConnection(string containerId)
    {
        return ClientConnection.GetContainer("Music", containerId);
    }



}