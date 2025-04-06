namespace Duckpond.TimeTracker.App.Repositories;

[Service(ServiceLifetime.Scoped)]
public class EmployeeRepository : IRepository<Employee>
{
    private IList<Employee> Employees { get; set; } = new List<Employee>();

    public Employee? GetById(int id)
    {
        return Employees.FirstOrDefault(e => e.Id == id);
    }

    public IEnumerable<Employee> GetAll()
    {
        return Employees;
    }

    public void Add(Employee model)
    {
        Employees.Add(model);
    }

    public void Update(Employee model)
    {
        Employees.Remove(model);
        Employees.Add(model);
    }

    public void Delete(int id)
    {
        var employee = GetById(id);
        if (employee is null) return;
        Delete(employee);
    }

    public void Delete(Employee model)
    {
        Employees.Remove(model);
    }
}