
using AlarmingTrafficWP8.Behaviors;
using AlarmingTrafficWP8.Messages;
using AlarmingTrafficWP8.Model;
using AlarmingTrafficWP8.Service;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace AlarmingTrafficWP8.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class LocationViewModel<TLocation> : ViewModelBase
        where TLocation : Location, new()
    {
        private readonly ILocationDataService _locationDataService;
        private readonly INavigationService _navigationService;

        private ObservableCollection<TLocation> _locations = new ObservableCollection<TLocation>();

        public ObservableCollection<TLocation> Locations
        {
            get
            {
                return this._locations;
            }
        }


        private TLocation _selectedLocation;

        public TLocation SelectedLocation
        {
            get { return this._selectedLocation; }
            set
            {
                Set(() => SelectedLocation, ref _selectedLocation, value);
            }
        }


        private TLocation _newLocation;

        public TLocation NewLocation
        {
            get
            {
                return _newLocation;
            }
            set
            {
                Set(() => NewLocation, ref _newLocation, value);
                //SaveNewLocationCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand SaveNewLocationCommand
        {
            get { return new RelayCommand(SaveNewLocation); }
        }


        private RelayCommand<SelectionChangedEventArgs> _selectionChangedCommand;

        public RelayCommand<SelectionChangedEventArgs> SelectionChangedCommand
        {
            get
            {
                //return new RelayCommand<SelectionChangedEventArgs>(SelectionChanged);
                return _selectionChangedCommand ?? (_selectionChangedCommand = new RelayCommand<SelectionChangedEventArgs>(SelectionChanged));
            }
        }

        public RelayCommand GoBackCommand { get; set; }


        /// <summary>
        /// Initializes a new instance of the LocationViewModel class.
        /// </summary> 
        public LocationViewModel(
            ILocationDataService locationDataService,
            INavigationService navigationService)
        {
            _locationDataService = locationDataService;
            _navigationService = navigationService;

            GoBackCommand = new RelayCommand(GoBack);

            NewLocation = new TLocation();

            LoadLocations();
        }


        private async void LoadLocations()
        {
            _locations.Clear();
            var locations = await _locationDataService.LoadLocations();
            foreach (var location in locations.OfType<TLocation>())
                _locations.Add(location);
        }

        private async void SaveNewLocation()
        {
            await _locationDataService.SaveLocation(NewLocation);
            LoadLocations();
            NewLocation = new TLocation();
        }


        // See if MVVMLight tutorial has a much better way (if we have problems with this method)
        private void SelectionChanged(SelectionChangedEventArgs args)
        {
            if (args.AddedItems.Count > 0)
            {
                Messenger.Default.Send(new LocationSelectedMessage(args.AddedItems[0] as TLocation));
                _navigationService.NavigateTo(new Uri(@"/View/LocationEditView.xaml", UriKind.Relative));
            }
        }

        // Go back
        private void GoBack()
        {
            if (_navigationService.CanGoBack)
                _navigationService.GoBack();
            else
                return;
        }

        public override void Cleanup()
        {
            base.Cleanup();

        }
    }
}

// Set(() => , ref , value);
// http://msdn.microsoft.com/en-us/magazine/dn759439.aspx - OneDrive Support
// http://here.com/help/wp8/drive/coverage - Supported countries and areas
/* http://stevenhollidge.blogspot.com/2012/03/viewmodels-for-enums.html - generic viewmodels
 * http://joyfulwpf.blogspot.com/2009/05/mvvm-developing-generic-mediator-class.html
 * http://www.dotnetcurry.com/showarticle.aspx?ID=1037 - Using MVVM Light in WPF for Model-View-ViewModel implementation
 * http://www.telerik.com/windows-phone/todo-lists-sample-app
 * http://blogs.telerik.com/windowsphoneteam/posts/11-03-30/implementing-wp7-todo-application-part1---getting-started.aspx
 * http://blogs.telerik.com/windowsphoneteam/posts/11-03-30/implementing-wp7-todo-application-part2---building-the-home-screen.aspx
 * http://blogs.telerik.com/valentinstoychev/posts/11-03-30/implementing-wp7-todo-application-part3---adding-richness-and-device-features.aspx
 * http://sustainablesources.com/resources/country-abbreviations/
*/
// http://www.bitboost.com/ref/international-address-formats.html - international mailing addresses (find actual addresses)
// http://www.upu.int/en/activities/addressing/postal-addressing-systems-in-member-countries.html - another one
// http://www.pedrolamas.com/2013/03/05/cimbalino-windows-phone-toolkit-applicationbarbehavior/
// http://www.pedrolamas.com/2013/03/11/cimbalino-windows-phone-toolkit-multiapplicationbarbehavior/
// http://www.spikie.be/blog/post/2013/01/29/SQLite-in-Windows-Phone-8
// http://www.alextells.com/mvvmlight-step-by-step-tut-create-a-windows-phone-runtime-app-and-convert-it-to-an-mvvmlight-app/
// http://www.codeguru.com/win_mobile/phone_apps/working-with-the-longlistselector-control-in-windows-phone-applications.htm
// http://blogs.msdn.com/b/msgulfcommunity/archive/2013/06/18/implementing-longlistselector-as-jumplists-in-windows-phone-8-alphabetical-list.aspx
// http://blogs.windows.com/buildingapps/2013/05/23/windows-phone-8-xaml-longlistselector/
// http://www.visuallylocated.com/post/2014/04/28/Migrating-from-the-LongListSelector-to-the-ListView-in-Windows-Phone-XAML-Apps.aspx
// http://stackoverflow.com/questions/20030224/how-to-populate-longlistselector
// http://lancelarsen.com/persisting-skydrive-login-on-windows-phone-8-via-livesdk/
// http://msicc.net/ - Prevent aaplication exit
// http://www.geekchamp.com/marketplace/components/perfectile - may need it someday
// http://blogs.telerik.com/vladimirenchev/posts/13-04-22/how-to-quick-export-to-excel-(xlsx)-for-wpf-and-silverlight
// http://www.saramgsilva.com/index.php/2012/export-to-csv-windows-8-store-apps/
// Essential Studio Windows Phone - exports to excel - healthchart perhaps?
// http://axilis.com/blogs/ikaracic/progress-indication-windows-phone
// http://stackoverflow.com/questions/14586521/bind-viewmodel-to-item-from-longlistselector-in-datatemplate/14600157#14600157
// http://cbailiss.wordpress.com/2014/01/24/windows-phone-8-longlistselector-memory-leak/
// http://stackoverflow.com/questions/10373012/convert-pivotitem-into-usercontrol-to-improve-loading-performance-in-wp7
// https://github.com/ErikSchierboom/pivotcontentdemo/tree/master/PivotContentDemo
// 



