namespace WebAPITest.Domain.Models;

public class PracticeSession
{
    public string? id { get; set; }
    
    public string? userId { get; set; }
    
    public TimeSpan? Length { get; set; }
    public DateTime? Date { get; set; }

    public List<FocusPoint>? FocusPoints { get; set; }


}