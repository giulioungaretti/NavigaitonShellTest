using NavigationShellTest.ViewModels;

namespace NavigationShellTest.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>

public sealed partial class BlankPage1 : Microsoft.UI.Xaml.Controls.Page
{
    public BlankPage1()
    {
        ViewModel = App.GetService<BlankPageViewModel>();
        InitializeComponent();
    }

    public BlankPageViewModel ViewModel { get; }
}
