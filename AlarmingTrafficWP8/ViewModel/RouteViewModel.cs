using AlarmingTrafficWP8.Behaviors;
using AlarmingTrafficWP8.Messages;
using AlarmingTrafficWP8.Model;
using AlarmingTrafficWP8.Service;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AlarmingTrafficWP8.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class RouteViewModel : ViewModelBase
    {
        private readonly IRouteDataService _routeDataService;
        private readonly INavigationService _navigationService;

       

        public RouteViewModel(
            IRouteDataService routeDataService,
            INavigationService navigationService
            )
        {
            _routeDataService = routeDataService;
            _navigationService = navigationService;
            GoBackCommand = new RelayCommand(GoBack);

        }

     

        /// Go back
        private void GoBack()
        {
            _navigationService.GoBack();
        }

        public RelayCommand GoBackCommand { get; set; }

          public override void Cleanup()
        {
            base.Cleanup();
         
        }
    }
}

// Set(() => , ref , value);