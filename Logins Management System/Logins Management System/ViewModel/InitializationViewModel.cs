using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using LoginsManagementSystem.Utilities;
using Windows.UI.Xaml;

namespace LoginsManagementSystem.ViewModel
{
    public class InitializationViewModel : ViewModelBase
    {
        #region Proporty 

        public Enumeration Result { get; private set; }

        public const string UserNamePropertyName = "UserName";
        private string _userName;
        public string UserName 
        {
            get
            {
                return _userName;
            }
            set
            {
                Set(UserNamePropertyName, ref _userName, value);
            }
        }

        public const string PasswordPropertyName = "Password";
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                Set(PasswordPropertyName, ref _password, value);
            }
        }

        public const string EncryptionSeedPropertyName = "EncryptionSeed";
        private string _encryptionSeed;
        public string EncryptionSeed
        {
            get
            {
                return _encryptionSeed;
            }
            set
            {
                Set(EncryptionSeedPropertyName, ref _encryptionSeed, value);
            }
        }


        public const string ErrorLabelPropertyName = "ErrorLabel";
        private string _errorLabel;
        public string ErrorLabel
        {
            get
            {
                return _errorLabel;
            }
            set
            {
                Set(ErrorLabelPropertyName, ref _errorLabel, value);
            }
        }

        #endregion

        #region RelayCommand

        private RelayCommand _primaryButtonCommand;
        public RelayCommand PrimaryButtonCommand
        {
            get
            {
                return _primaryButtonCommand
                       ?? (_primaryButtonCommand = new RelayCommand(
                           () =>
                           {
                               if (String.IsNullOrWhiteSpace(UserName))
                               {
                                   ErrorLabel = "User name is required.";
                                   Result = Enumeration.SignInFail;
                                   return;
                               }
                               else if (String.IsNullOrWhiteSpace(Password))
                               {
                                   ErrorLabel = "Password is required.";
                                   Result = Enumeration.SignInFail;
                                   return;
                               }
                               else if (String.IsNullOrWhiteSpace(EncryptionSeed))
                               {
                                   ErrorLabel = "Seed is required.";
                                   Result = Enumeration.SignInFail;
                                   return;
                               }

                               if (ComplexityVerification.CheckStrength(Password) != Score.VeryStrong)
                               {
                                   ErrorLabel = "Password is not complex enough.";
                                   Result = Enumeration.SignInFail;
                                   return;
                               }

                               if (ComplexityVerification.CheckStrength(EncryptionSeed) != Score.VeryStrong)
                               {
                                   ErrorLabel = "Seed is not complex enough.";
                                   Result = Enumeration.SignInFail;
                                   return;
                               }
                               //inset in the database
                               Result = Enumeration.SignInOK;

                           }));
            }
        }

        private RelayCommand _secondaryButtonCommand;
        public RelayCommand SecondaryButtonCommand
        {
            get
            {
                return _secondaryButtonCommand
                       ?? (_secondaryButtonCommand = new RelayCommand(
                           () =>
                           {
                               Application.Current.Exit();
                           }));
            }
        }

        #endregion
    }
}
