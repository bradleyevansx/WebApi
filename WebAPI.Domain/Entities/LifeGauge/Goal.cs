namespace Models;

public class Goal
{
    public string? Title { get; set; }

    public List<SubGoal> SubGoals { get; set; } = new();
    
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
}