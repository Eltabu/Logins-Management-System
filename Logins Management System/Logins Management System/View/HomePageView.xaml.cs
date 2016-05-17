using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace LoginsManagementSystem.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePageView : Page
    {
        public HomePageView()
        {
            this.InitializeComponent();

            // I want this page to be always cached so that we don't have to add logic to save/restore state.
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }
    }
}
