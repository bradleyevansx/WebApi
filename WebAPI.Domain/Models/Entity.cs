namespace WebAPITest.Domain.Models;

public abstract class Entity
{
    public string? Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public abstract string? PartitionKey { get; }
}