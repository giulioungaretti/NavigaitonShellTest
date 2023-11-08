using CommunityToolkit.Mvvm.ComponentModel;

using NavigationShellTest.Services;

namespace NavigationShellTest.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly INavigationService navigationService;

    public MainWindowViewModel(INavigationService navigationService) => this.navigationService = navigationService;

    [ObservableProperty]
    public string selected;

    public void NavigateToPage(string itemInvoked)
    {
        navigationService.NavigateToPage(itemInvoked);
        Selected = itemInvoked;
    }
}
