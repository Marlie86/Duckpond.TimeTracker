namespace Duckpond.TimeTracker.App.Repositories;

[Service(ServiceLifetime.Scoped)]
public class EmployeeRepository : GenericRepository<Employee>
{
    private readonly string _filepath;

    public EmployeeRepository(IConfiguration configuration)
    {
        _filepath = Path.Combine(
            configuration["DataDictionary"] ?? throw new ArgumentNullException("Could not find DataDictionary."),
            "employee.json");
        var directory = Path.GetDirectoryName(_filepath);
        if (directory is not null && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        Load();
    }

    public sealed override void Load()
    {
        if (!File.Exists(_filepath)) return;
        Models = JsonSerializer.Deserialize<List<Employee>>(File.ReadAllText(_filepath)) ?? new List<Employee>();
    }

    public override void Save()
    {
        var json = JsonSerializer.Serialize(Models);
        File.WriteAllText(_filepath, json);
    }
}