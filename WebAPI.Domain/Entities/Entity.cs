namespace WebAPI.Domain.Models;

public abstract class Entity
{
    public string? id { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public abstract string? PartitionKey { get;}
}