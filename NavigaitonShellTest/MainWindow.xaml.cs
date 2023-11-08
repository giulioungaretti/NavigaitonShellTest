using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using NavigationShellTest.ViewModels;

using System.Collections.Generic;
using System.Diagnostics;

namespace NavigationShellTest;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public partial class MainWindow : Window
{
    private readonly MainWindowViewModel vm;
    public MainWindow(MainWindowViewModel vm)
    {
        InitializeComponent();
        this.vm = vm;

        // set up all our pages
        List<Pages.Pages> pages = new() {
            new Pages.Pages.BlankPage1(),
            new Pages.Pages.BlankPage2()
        };

        // add them to the sidebar
        foreach (Pages.Pages page in pages)
        {
            (string tag, string name) = page.Details();
            NavigationView.MenuItems.Add(new NavigationViewItem
            {
                Content = name,
                Tag = tag
            });
        };
    }

    public Frame CF => ContentFrame;

    private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        // get the navigation service
        // navigate to an **existing** page (compile time checking!)
        {
            if (args.IsSettingsInvoked)
            {
                //ContentFrame.Navigate(typeof(SettingsPage));
                Debug.WriteLine("settingsInvoked");
            }
            else
            {
                object tag = args.InvokedItemContainer.Tag;
                Debug.WriteLine(tag);
                vm.NavigateToPage((string)tag);
            }
        }

    }
}
