namespace Duckpond.TimeTracker.App.Models;

public class TimeTrackItem
{
    public int Id { get; set; } = 0;
    public Employee Employee { get; set; } = new Employee();
    public MainProject Project { get; set; } = new MainProject();
    public DateTime Start { get; set; } = DateTime.Now;
    public DateTime? End { get; set; } = null;
}