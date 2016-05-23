using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using LoginsManagementSystem.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using LoginsManagementSystem.View;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace LoginsManagementSystem.ViewModel
{
    /// <summary>
    /// Public class provides the logic for the MainView
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Proporty 

        private readonly IDataService _dataService;

        public const string MokListPropertyName = "MokList";
        private List<string> _mokList;
        public List<string> MokList
        {
            get
            {
                return _mokList;
            }
            set
            {
                Set(MokListPropertyName, ref _mokList, value);
            }
        }
        private string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                if (value == string.Empty)
                {
                    MokList = null;
                }
                else
                {
                    MokList = new List<string> { "Moad", "Eltabu", "Steven" };
                }
                Set("SearchText", ref _searchText, value);
            }
        }


        #endregion

        #region RelayCommand

        private RelayCommand _logInCommand;
        public RelayCommand LogInCommand
        {
            get
            {
                return _logInCommand
                       ?? (_logInCommand = new RelayCommand(
                           async () =>
                           {
                               if (!_dataService.IsFirstTime())
                               {
                                   InitializationView dialog = new InitializationView();
                                   await dialog.ShowAsync();
                               }
                               else
                               {
                                   SignInView dialog = new SignInView();
                                   await dialog.ShowAsync();

                                   if (dialog.Result == SignInResult.SignInOK)
                                   {
                                       //this.MainFrame.Navigate(typeof(MainPage));
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
                           }));
            }
        }


        private RelayCommand<Frame> _navigationBackButtonCommand; 
        public RelayCommand<Frame> NavigationBackButtonCommand 
        {
            get
            {
                return _navigationBackButtonCommand
                       ?? (_navigationBackButtonCommand = new RelayCommand<Frame>(
                           (MainFrame) =>
                           {
                               if (MainFrame.CanGoBack)
                               {
                                   MainFrame.GoBack();
                               }
                           }));
            }
        }

        #endregion

        #region Methods

        #endregion

        #region Constructor

        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        #endregion


        }
}

