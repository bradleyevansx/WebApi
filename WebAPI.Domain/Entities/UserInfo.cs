using Microsoft.Azure.Cosmos;

namespace WebAPI.Domain.Models;

public class UserInfo : Entity
{
    public UserType? UserType { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public override string? PartitionKey => id;
}