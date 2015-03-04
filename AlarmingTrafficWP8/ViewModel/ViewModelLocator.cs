/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:AlarmingTrafficWP8"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using AlarmingTrafficWP8.Behaviors;
using AlarmingTrafficWP8.Messages;
using AlarmingTrafficWP8.Model;
using AlarmingTrafficWP8.Service;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AlarmingTrafficWP8.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {

        public static ViewModelLocator Instance
        {
            get
            {
                return Application.Current.Resources["Locator"] as ViewModelLocator;
            }
        }

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
            {
                //SimpleIoc.Default.Register<INavigationService, NavigationService>();
                SimpleIoc.Default.Register<INavigationService>(() => new NavigationService());
            }

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                SimpleIoc.Default.Register<ILocationDataService, LocationDesignDataService>();
                SimpleIoc.Default.Register<IRouteDataService, RouteDesignDataService>();
            }
            else
            {
                // Create run time view services and models
                SimpleIoc.Default.Register<ILocationDataService, LocationDataService>();
                SimpleIoc.Default.Register<IRouteDataService, RouteDataService>();
                //SimpleIoc.Default.Register<INavigationService, NavigationService>();
            }


            //SimpleIoc.Default.Register<IDataService, DataService>();


            //SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LocationViewModel<LocationUS>>();
            SimpleIoc.Default.Register<LocationEditViewModel>(true);
            //SimpleIoc.Default.Register<LocationEditViewModel>();
            SimpleIoc.Default.Register<RouteViewModel>();
            //SimpleIoc.Default.Register<RouteEditViewModel>(true);
        }

        public LocationViewModel<LocationUS> LocationViewModel
        {
            //get { return SimpleIoc.Default.GetInstance<LocationViewModel>(); }
            get { return ServiceLocator.Current.GetInstance<LocationViewModel<LocationUS>>(); }
        }

        public LocationEditViewModel LocationEditViewModel
        {
            //get { return SimpleIoc.Default.GetInstance<LocationEditViewModel>(); }
            get { return ServiceLocator.Current.GetInstance<LocationEditViewModel>(); }
        }

        public RouteViewModel RouteViewModel
        {
            //get { return SimpleIoc.Default.GetInstance<RouteViewModel>(); }
            get { return ServiceLocator.Current.GetInstance<RouteViewModel>(); }
        }

        /// <summary>
        /// Cleanups this instance.
        /// </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels

            Instance.LocationEditViewModel.Cleanup();
            Instance.LocationViewModel.Cleanup();
            // Instance.RouteEditViewModel.Cleanup();
            Instance.RouteViewModel.Cleanup();

            // I wonder if that public static ViewModelLocator Instance could be used here??
            /*
            var viewModelLocator = (ViewModelLocator)Application.Current.Resources["Locator"];
            viewModelLocator.LocationEditViewModel.Cleanup();            
            viewModelLocator.LocationViewModel.Cleanup();
            // viewModelLocator.RouteEditViewModel.Cleanup();
            viewModelLocator.RouteViewModel.Cleanup();
            */

            Messenger.Reset();
            // Messenger.Default.Send<CleanUp>(new CleanUp());
        }



        //public MainViewModel Main
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<MainViewModel>();
        //    }
        //}


    }
}