namespace Duckpond.TimeTracker.App.Models;

public class Employee : BaseModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string EmplyeeNumber { get; set; } = string.Empty;
}