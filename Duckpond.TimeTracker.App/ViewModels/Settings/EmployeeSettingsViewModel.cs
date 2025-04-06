namespace Duckpond.TimeTracker.App.ViewModels.Settings;

[Service(ServiceLifetime.Scoped)]
public class EmployeeSettingsViewModel : BaseViewModel
{
    private readonly ILogger<EmployeeSettingsViewModel> _logger;
    private readonly EmployeeRepository _employeeRepository;
    private readonly ISnackbar _snackbar;

    private Employee? _originalEmployee = null;
    private Employee? _employee = null;
    public Employee Employee
    {
        get => _employee ??= GetEmployee();
        set => SetField(ref _employee, value);
    }

    public EmployeeSettingsViewModel(
        ILogger<EmployeeSettingsViewModel> logger,
        EmployeeRepository employeeRepository,
        ISnackbar snackbar)
    {
        _logger = logger;
        _employeeRepository = employeeRepository;
        _snackbar = snackbar;
    }

    public async Task SaveAsync()
    {
        _logger.LogInformation("Saving employee settings.");
        if (_employee is null) return;
        await Task.Run(() =>
        {
            _employeeRepository.Update(_employee);
            _employeeRepository.Save();
            _originalEmployee = _employee.Clone();
            _snackbar.Add("Employee settings saved.", Severity.Success);
        });
    }

    public void CancelEdit()
    {
        _logger.LogInformation("Revert chanings to employee settings.");
        _employee = _originalEmployee.Clone();
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