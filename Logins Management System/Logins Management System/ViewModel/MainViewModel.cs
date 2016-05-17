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

namespace LoginsManagementSystem.ViewModel
{
    /// <summary>
    /// Public class provides the logic for the MainView
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Proporty 

        //public const string NamePropertyName = "Name";
        //private string _name;
        //public string Name
        //{
        //    get
        //    {
        //        return _name;
        //    }
        //    set
        //    {
        //        Set(NamePropertyName, ref _name, value);
        //    }
        //}


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
                               SignIn dialog = new SignIn();
                               await dialog.ShowAsync();

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
                           }));
            }
        }

        #endregion

        #region Methods

        #endregion


    }
}

