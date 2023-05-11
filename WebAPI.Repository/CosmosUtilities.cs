using Microsoft.Azure.Cosmos;
using WebAPITest.Domain.Models;

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
    
    public static async Task<T> CheckUsernameAndPassword<T>(this Container container, NewUser newUser)
    {
        var results = container.GetItemQueryIterator<T>($"SELECT * FROM c WHERE c.Username = '{newUser.Username}' AND c.Password = '{newUser.Password}'");
        T item = default;
        while (results.HasMoreResults)
        {
            var response = await results.ReadNextAsync();
            return response.FirstOrDefault();
        }

        throw new Exception("Did not find object");
    }
}