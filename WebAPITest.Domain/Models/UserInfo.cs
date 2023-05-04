namespace WebAPITest.Domain.Models;

public record UserInfo
{
    public string? id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}