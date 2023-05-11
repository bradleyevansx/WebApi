namespace WebAPITest.Domain.Models;

public class PracticeSession : Entity
{
    public string? userId { get; set; }
    public string? Title { get; set; }
    public TimeSpan? Length { get; set; }
    public DateTime? Date { get; set; }
    public List<FocusPoint>? FocusPoints { get; set; }


    public override string? PartitionKey => userId;
}