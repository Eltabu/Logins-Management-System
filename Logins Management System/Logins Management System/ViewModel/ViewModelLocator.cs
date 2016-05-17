using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using LoginsManagementSystem.Model;
using LoginsManagementSystem.View;

namespace LoginsManagementSystem.ViewModel
{
    public class ViewModelLocator
    {
        public const string HomePageViewKey = "HomePageView";

        static ViewModelLocator()
        {
            var nav = new NavigationService();
            nav.Configure(HomePageViewKey, typeof(HomePageView));
            SimpleIoc.Default.Register<INavigationService>(() => nav);

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IDialogService, DialogService>();

            SimpleIoc.Default.Register<IDataService, DataService>();

            SimpleIoc.Default.Register<MainViewModel>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
    }
}
