//using AlarmingTrafficWP8.Helpers;
using AlarmingTrafficWP8.Behaviors;
using AlarmingTrafficWP8.Messages;
using AlarmingTrafficWP8.Model;
using AlarmingTrafficWP8.Service;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Maps.Services;
using Microsoft.Phone.Maps.Toolkit;
using Microsoft.Phone.Reactive;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Device.Location;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Windows.Devices.Geolocation;
using Windows.UI;

namespace AlarmingTrafficWP8.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class LocationEditViewModel : ViewModelBase
    {
        private readonly ILocationDataService _locationDataService;
        private readonly INavigationService _navigationService;

        private LocationUS _selectedLocation;
        //private GeoCoordinate geo1 = null;
        private GeoCoordinate mapCenter = new GeoCoordinate(40.712923, -74.013292);

        /// <summary>
        /// Sets and gets the SelectedLocation property.
        /// </summary>
        public LocationUS SelectedLocation
        {
            get
            {
                return _selectedLocation;
            }

            set
            {
                Set(() => SelectedLocation, ref _selectedLocation, value);
            }
        }

        public RelayCommand UpdateLocationCommand
        {
            get { return new RelayCommand(UpdateLocation); }
        }

        public RelayCommand DeleteLocationCommand
        {
            get { return new RelayCommand(DeleteLocation); }
        }

        /// <summary>
        /// Initializes a new instance of the LocationEditViewModel class.
        /// </summary>
        public LocationEditViewModel(ILocationDataService locationDataService, INavigationService navigationService)
        {
            _locationDataService = locationDataService;
            _navigationService = navigationService;

            Messenger.Default.Register<LocationSelectedMessage>(this, msg => SelectedLocation = msg.Location);

            // getLocation();
        }


        private void UpdateLocation()
        {
            _locationDataService.UpdateLocation(SelectedLocation);            
            GoBack();
        }



        private void DeleteLocation()
        {
            _locationDataService.DeleteLocation(SelectedLocation);
            GoBack();
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





        #region MapStuff

        //public GeoCoordinate MapCenter
        //{
        //    get { return mapCenter; }
        //    set
        //    {
        //        Set(() => MapCenter, ref mapCenter, value);
        //    }
        //}
        //private double zoomLevel = 15;

        //public double ZoomLevel
        //{
        //    get { return zoomLevel; }
        //    set
        //    {
        //        Set(() => ZoomLevel, ref zoomLevel, value);
        //    }
        //}


        //private void getLocation()
        //{
        //    geo1 = null;

        //    if (SelectedLocation != null)
        //    {
        //       getGeoCoordinate(SelectedLocation); 
        //    }

        //}

        //private void getGeoCoordinate(LocationUS selectedLocation)
        //{
        //    string address = String.Empty;

        //    if (!String.IsNullOrEmpty(selectedLocation.LocationStreetAddress))
        //    {
        //        if (String.IsNullOrEmpty(selectedLocation.LocationZIP))
        //        {
        //            if ((!String.IsNullOrEmpty(selectedLocation.LocationCity)) && (!String.IsNullOrEmpty(selectedLocation.LocationState)))
        //            {
        //                address = string.Format("{0}, {1}, {2}", selectedLocation.LocationStreetAddress, selectedLocation.LocationCity, selectedLocation.LocationState);
        //            }
        //            else return;
        //        }
        //        else
        //            address = string.Format("{0} {1}", selectedLocation.LocationStreetAddress, selectedLocation.LocationZIP);
        //    }
        //    else
        //    {
        //        return;
        //    }

        //    GeocodeQuery query = new GeocodeQuery()
        //    {
        //        GeoCoordinate = new GeoCoordinate(0, 0),

        //        SearchTerm = address
        //    };

        //    query.QueryCompleted += geoCoordinateQuery_QueryCompleted;
        //    query.QueryAsync();
        //}

        //private void geoCoordinateQuery_QueryCompleted(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
        //{
        //    var map = sender as Map;
        //    var item = e.Result;

        //    if (item.Count() == 0)
        //    {
        //        //MessageBox.Show("No GeoCoordinate found!");
        //        return;
        //    }
        //    if (item.ElementAt(0).GeoCoordinate == null)
        //    {
        //        //MessageBox.Show("No GeoCoordinate found!");
        //        return;
        //    }
        //    if (this.geo1 == null)
        //    {
        //        this.geo1 = item.ElementAt(0).GeoCoordinate;

        //    }

        //    if (this.geo1 != null)
        //    {
        //        MapCenter = geo1;
        //        //ZoomLevel = 13;
        //        // remove possible previous one layer
        //        //if (map.Layers.Count() > 0) map.Layers.Clear();
        //        AddMapLayer(geo1, map, Colors.Blue);
        //        //AddMapLayer(geo2, Colors.Red);
        //        //FindRoute(); var map = sender as Map;
        //    }
        //}

        //private void AddMapLayer(GeoCoordinate geo1, Map map, System.Windows.Media.Color color)
        //{
        //    map.Layers.Add(new MapLayer()
        //    {
        //        new MapOverlay()
        //        {
        //            GeoCoordinate = geo1,
        //            PositionOrigin = new Point(0.5,0.5),
        //            Content = new Ellipse
        //            {
        //                Fill = new SolidColorBrush(color),
        //                Width = 20,
        //                Height = 20
        //            }
        //        }
        //    });
        //}




        //private Pushpin MyPushpin { get; set; }

        //ObservableCollection<DependencyObject> children = MapExtensions.GetChildren(NokiaMap);       
        //var pin = children.FirstOrDefault(x => x.GetType() == typeof(Pushpin)) as Pushpin;
        //MyPushpin = pin;



        #endregion
    }
}

