namespace Duckpond.TimeTracker.App.ViewModels.Home;
public class HomeViewModel : BaseViewModel
{
    private readonly ILogger<HomeViewModel> _logger;

    public HomeViewModel(ILogger<HomeViewModel> logger)
    {
        _logger = logger;
    }
}