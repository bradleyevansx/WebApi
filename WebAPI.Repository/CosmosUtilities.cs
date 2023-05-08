using Microsoft.Azure.Cosmos;

namespace WebAPITest.Repository;

public static class CosmosUtilities
{
    public static async Task<T> FirstAsync<T>(this Container container, string id)
    {
        var results = container.GetItemQueryIterator<T>($"SELECT * FROM c where c.id = '{id}'");
        T item = default;
        while (results.HasMoreResults)
        {
            var response = await results.ReadNextAsync();
            return response.FirstOrDefault();
        }

        throw new Exception("Did not find object");
    }
}