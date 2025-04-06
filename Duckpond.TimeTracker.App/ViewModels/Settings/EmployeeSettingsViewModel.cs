using Duckpond.TimeTracker.Common.Extensions;

namespace Duckpond.TimeTracker.App.ViewModels.Settings;

[Service(ServiceLifetime.Scoped)]
public class EmployeeSettingsViewModel : BaseViewModel
{
    private readonly ILogger<EmployeeSettingsViewModel> _logger;
    private readonly EmployeeRepository _employeeRepository;

    private Employee? _originalEmployee = null;
    private Employee? _employee = null;
    public Employee Employee
    {
        get => _employee ??= GetEmployee();
        set => SetField(ref _employee, value);
    }

    public EmployeeSettingsViewModel(ILogger<EmployeeSettingsViewModel> logger, EmployeeRepository employeeRepository)
    {
        _logger = logger;
        _employeeRepository = employeeRepository;
    }

    public async Task SaveAsync()
    {
        _logger.LogInformation("Saving employee settings.");
        if (_employee is null) return;
        await Task.Run(() => _employeeRepository.Update(_employee));
    }

    public void CancelEdit()
    {
        _logger.LogInformation("Revert chanings to employee settings.");
        _employee = _originalEmployee;
    }

    private Employee GetEmployee()
    {
        var employee = _employeeRepository.GetById(1);
        if (employee is null)
        {
            _logger.LogWarning("Employee not found, create a new employee.");
            employee = new Employee
            {
                Id = 1
            };
        }
        _originalEmployee = employee.Clone();
        return employee;
    }
}