using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using NavigationShellTest.Services;

using static NavigationShellTest.Pages.Pages;

namespace NavigationShellTest.ViewModels;
public partial class BlankPageViewModel : ObservableObject
{

    private readonly INavigationService navigationService;
    public BlankPageViewModel(INavigationService navigationService) => this.navigationService = navigationService;

    [RelayCommand]
    public void NavigateToPage2() => navigationService.NavigateToPage(new BlankPage2());
}
