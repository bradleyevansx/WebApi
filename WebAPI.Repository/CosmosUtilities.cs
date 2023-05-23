using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using WebAPI.Domain.Models;

namespace WebAPI.Repository;

public static class CosmosUtilities
{
    public static async Task<List<T>> ToListAsync<T>(this IQueryable<T> query)
    {
        var response = query.ToFeedIterator();
        var results = new List<T>();
        while (response.HasMoreResults)
        {
            var newItems = await response.ReadNextAsync();
            results.AddRange(newItems);
        }

        return results;


    }
    public static async Task<T?> FirstAsync<T>(this Container container, string id)
    {
        var results = container.GetItemQueryIterator<T>($"SELECT * FROM c where c.id = '{id}'");
        while (results.HasMoreResults)
        {
            var response = await results.ReadNextAsync();
            return response.FirstOrDefault();
        }

        throw new Exception("Did not find object");
    }
}