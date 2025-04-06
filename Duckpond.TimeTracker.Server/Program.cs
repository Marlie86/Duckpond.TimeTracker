using Duckpond.TimeTracker.App.ViewModels.Home;
using Duckpond.TimeTracker.Common.Extensions;

namespace Duckpond.TimeTracker.Server;
internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        builder.Services.AddMudServices();

        builder.Services.AddAttributedServiesFromAssembly(typeof(HomeViewModel).Assembly);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<UI.App>()
            .AddAdditionalAssemblies([typeof(Home).Assembly])
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}