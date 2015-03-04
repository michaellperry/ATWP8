using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlarmingTrafficWP8.Model;

namespace AlarmingTrafficWP8.Service
{
    public interface IRouteDataService
    {
        Task SaveRoute(Route newRoute);
        Task<ObservableCollection<Route>> LoadRoutes();
        Task UpdateRoute(Route selectedRoute);
        Task DeleteRoute(Route selectedRoute);
    }
}


///  Load the locations in the Route DAL - Think SubTask ;)
///  
