using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

using NavigationShellTest.Services;
using NavigationShellTest.ViewModels;

using System;

namespace NavigationShellTest;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    public readonly IHost Host;
    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        InitializeComponent();
        Host = Microsoft.Extensions.Hosting.Host
            .CreateDefaultBuilder()
            .UseContentRoot(AppContext.BaseDirectory)
            .ConfigureServices((context, services) =>
            {
                // TODO: Activation Handlers
                // For now on activation we default to going to the main window

                // Services
                _ = services.AddSingleton<INavigationService, NavigationService>();

                // ViewModels
                _ = services.AddTransient<MainWindowViewModel>();
                _ = services.AddTransient<BlankPageViewModel>();

            }
            ).Build();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args) => MainWindow.Activate();

    public static MainWindow MainWindow { get; } = new(App.GetService<MainWindowViewModel>());

    # region: GetService
    public static T GetService<T>()
        where T : class => (App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service
            ? throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.")
            : service;
    #endregion
}
