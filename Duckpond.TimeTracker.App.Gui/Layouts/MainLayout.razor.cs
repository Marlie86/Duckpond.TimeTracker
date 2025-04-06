namespace Duckpond.TimeTracker.App.Gui.Layouts;

public partial class MainLayout
{
    bool _drawerOpen = true;
    void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }
}