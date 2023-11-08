using Microsoft.UI.Xaml.Controls;

namespace NavigationShellTest.Services;

public class NavigationService : INavigationService
{
    internal static Frame Frame => App.MainWindow.CF;
    #region the future
    //public bool NavigateToPage(string pageKey, object? parameter = null, bool clearNavigation = false)
    //{
    //    //var pageType = _pageService.GetPageType(pageKey);

    //    if (_frame != null && (_frame.Content?.GetType() != pageType || (parameter != null && !parameter.Equals(_lastParameterUsed))))
    //    {
    //        _frame.Tag = clearNavigation;
    //        var vmBeforeNavigation = _frame.GetPageViewModel();
    //        bool navigated = _frame.Navigate(pageType, parameter);
    //        if (navigated)
    //        {
    //            _lastParameterUsed = parameter;
    //            if (vmBeforeNavigation is INavigationAware navigationAware)
    //            {
    //                navigationAware.OnNavigatedFrom();
    //            }
    //        }

    //        return navigated;
    //    }

    //    return false;
    //}
    #endregion

    public void NavigateToPage(string target) => Frame.Navigate(Pages.Pages.GetView(target));
    public void NavigateToPage(Pages.Pages target) => Frame.Navigate(Pages.Pages.GetView(target));
}
