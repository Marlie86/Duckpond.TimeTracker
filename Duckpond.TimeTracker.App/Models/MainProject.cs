namespace Duckpond.TimeTracker.App.Models;

public class MainProject
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public IEnumerable<SubProject> SubProjects { get; set; } = new List<SubProject>();
}