namespace Models;

public class LifeSector
{
    public string? Title { get; set; }
    public List<Goal>? Goals { get; set; } = new();
    
    public double? Progress => Goals.Count > 0 ? Goals.Count(g => g.IsCompleted) * 100.0 / Goals.Count : 0;
}