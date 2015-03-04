using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlarmingTrafficWP8.Model;

namespace AlarmingTrafficWP8.Service
{
    public class RouteDesignDataService : IRouteDataService
    {

       

        public async Task SaveRoute(Route newRoute)
        {
            await App.Connection.InsertAsync(newRoute);
        }

        public async Task<ObservableCollection<Route>> LoadRoutes()
        {
            // Make design data 
            var result = new ObservableCollection<Route>();
            //  Design the route creation view
            return result;


            

            //return await App.Connection.Table<Route>().ToListAsync();
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
            var result = new ObservableCollection<LocationUS>();

            for (int i = 0; i < 4; i++)
            {
                result.Add(
                   new LocationUS
                   {
                       LocationName = "PlaceName" + i,
                       LocationStreetAddress = "123 Address #" + i,
                       LocationCity = "City #" + i,
                       LocationState = "ST",
                       LocationZIP = "7511" + i
                   }
                   );
            }

            return result;
        }

    }
}
