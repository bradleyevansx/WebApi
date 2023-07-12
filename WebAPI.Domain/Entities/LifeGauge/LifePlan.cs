using WebAPI.Domain.Models;

namespace Models;

public class LifePlan : Entity
{
    public string? userId { get; set; }

    public string? Name { get; set; }

    public List<LifeSector>? LifeSectors { get; set; } = new();
    public override string? PartitionKey => userId;
    
    public bool? IsTest { get; set; }

}