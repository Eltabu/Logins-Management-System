using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class MasterPageView : Page
    {

        public MasterPageView()
        {
            this.InitializeComponent();
            this.RequestedTheme = ElementTheme.Dark;
#if DEBUG
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
#endif      
            }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            this.Splitter.IsPaneOpen = this.Splitter.IsPaneOpen ? false : true;
        }


        private void NavLinksList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as StackPanel;

            Frame rootFrame = Window.Current.Content as Frame;

            if (item != null)
            {
                switch (item.Tag.ToString())
                {
                    case "MainPage":
                        this.MainFrame.Navigate(typeof(MainPageView));
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

                    case "Setting":
                        this.MainFrame.Navigate(typeof(SettingView));
                        if (Window.Current.Bounds.Width < 640)
                        {
                            Splitter.IsPaneOpen = false;
                        }
                        break;


                    case "Exit":
                        Application.Current.Exit();
                        break;

                    default:
                        break;
                }
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {

            //SignIn dialog = new SignIn();
            //await dialog.ShowAsync();

            //if (dialog.Result == SignInResult.SignInOK)
            //{
            //    this.MainFrame.Navigate(typeof(MainPage));
            //}
            //else if (dialog.Result == SignInResult.SignInCancel)
            //{
            //    Application.Current.Exit();
            //}
            //else if (dialog.Result == SignInResult.Nothing)
            //{
            //    Application.Current.Exit();
            //}

        }

        private void ThemeToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            this.RequestedTheme = ElementTheme.Light;
        }

        private void ThemeToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            this.RequestedTheme = ElementTheme.Dark;
        }

        /// <summary>
        /// This event gets fired when:
        ///     * a user presses Enter while focus is in the TextBox
        ///     * a user clicks or tabs to and invokes the query button (defined using the QueryIcon API)
        ///     * a user presses selects (clicks/taps/presses Enter) a suggestion
        /// </summary>
        /// <param name="sender">The AutoSuggestBox that fired the event.</param>
        /// <param name="args">The args contain the QueryText, which is the text in the TextBox, 
        /// and also ChosenSuggestion, which is only non-null when a user selects an item in the list.</param>
        private void AutoSuggestName_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            //if (args.ChosenSuggestion != null)
            //{
            //    //User selected an item, take an action on it here
            //    SelectContact(args.ChosenSuggestion as Contact);
            //}
            //else
            //{
            //    //Do a fuzzy search on the query text
            //    var matchingContacts = ContactSampleDataSource.GetMatchingContacts(args.QueryText);

            //    if (matchingContacts.Count() >= 1)
            //    {
            //        //Choose the first match
            //        SelectContact(matchingContacts.FirstOrDefault());
            //    }
            //    else
            //    {
            //        NoResults.Visibility = Visibility.Visible;
            //    }
            //}
        }


        /// <summary>
        /// This event gets fired as the user keys through the list, or taps on a suggestion.
        /// This allows you to change the text in the TextBox to reflect the item in the list.
        /// Alternatively you can use TextMemberPath.
        /// </summary>
        /// <param name="sender">The AutoSuggestBox that fired the event.</param>
        /// <param name="args">The args contain SelectedItem, which contains the data item of the item that is currently highlighted.</param>
        private void AutoSuggestName_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            //var contact = args.SelectedItem as Contact;

            //sender.Text = string.Format("{0} ({1})", contact.FullName, contact.Company);
        }

        /// <summary>
        /// This event gets fired anytime the text in the TextBox gets updated.
        /// It is recommended to check the reason for the text changing by checking against args.Reason
        /// </summary>
        /// <param name="sender">The AutoSuggestBox whose text got changed.</param>
        /// <param name="args">The event arguments.</param>
        private void AutoSuggestName_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            //We only want to get results when it was a user typing, 
            //otherwise we assume the value got filled in by TextMemberPath 
            //or the handler for SuggestionChosen
            //if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            //{
            //    var matchingContacts = ContactSampleDataSource.GetMatchingContacts(sender.Text);

            //    sender.ItemsSource = matchingContacts.ToList();
            //}
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }
    }
}
