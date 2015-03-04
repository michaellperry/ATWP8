using AlarmingTrafficWP8.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmingTrafficWP8.Service
{
    public class RouteDataService : IRouteDataService
    {
        ObservableCollection<Route> _routes;
        ObservableCollection<LocationUS>  _locations;

        public async Task SaveRoute(Route newRoute)
        {
            await App.Connection.InsertAsync(newRoute);
        }

        public async Task<ObservableCollection<Route>> LoadRoutes()
        {
            _routes = new ObservableCollection<Route>();
            List<Route> list = await App.Connection.Table<Route>().ToListAsync();

            foreach (var item in list)
            {
                this._routes.Add(item);
            }

            return _routes;
        }

        public async Task UpdateRoute(Route selectedRoute)
        {
            await App.Connection.UpdateAsync(selectedRoute);
        }

        public async Task DeleteRoute(Route selectedRoute)
        {
            await App.Connection.DeleteAsync(selectedRoute);
        }

        public async Task<ObservableCollection<LocationUS>> LoadLocations()
        {
            _locations = new ObservableCollection<LocationUS>();
            List<LocationUS> list = await App.Connection.Table<LocationUS>().ToListAsync();

            foreach (var item in list)
            {
                this._locations.Add(item);
            }

            return _locations;
        }
    }
}