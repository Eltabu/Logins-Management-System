using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LoginsManagementSystem.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MasterPage : Page
    {
        public MasterPage()
        {
            this.InitializeComponent();
            this.RequestedTheme = ElementTheme.Dark;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            this.Splitter.IsPaneOpen = this.Splitter.IsPaneOpen ? false : true;
        }


        private void NavLinksList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as StackPanel;

            if (item != null)
            {
                switch (item.Tag.ToString())
                {
                    case "MainPage":
                        this.MainFrame.Navigate(typeof(MainPage));
                        if (Window.Current.Bounds.Width < 640)
                        {
                            Splitter.IsPaneOpen = false;
                        }
                        break;
                    case "AddLog":
                        this.MainFrame.Navigate(typeof(AddLogView));
                        if (Window.Current.Bounds.Width < 640)
                        {
                            Splitter.IsPaneOpen = false;
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SignIn dialog = new SignIn();
            await dialog.ShowAsync();

            if (dialog.Result == SignInResult.SignInOK)
            {
                this.MainFrame.Navigate(typeof(MainPage));
            }
            else if (dialog.Result == SignInResult.SignInCancel)
            {
                Application.Current.Exit();
            }
            else if (dialog.Result == SignInResult.Nothing)
            {
                Application.Current.Exit();
            }
        }

        private void ThemeToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            this.RequestedTheme = ElementTheme.Light;
        }

        private void ThemeToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            this.RequestedTheme = ElementTheme.Dark;
        }
    }
}
