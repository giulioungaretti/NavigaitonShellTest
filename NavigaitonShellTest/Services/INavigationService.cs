namespace NavigationShellTest.Services;
public interface INavigationService
{
    void NavigateToPage(string target);
    void NavigateToPage(Pages.Pages target);
}
