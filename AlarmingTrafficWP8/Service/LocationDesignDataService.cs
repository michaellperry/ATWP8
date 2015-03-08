using AlarmingTrafficWP8.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace AlarmingTrafficWP8.Service
{
    public class LocationDesignDataService : ILocationDataService 
    {
        public async Task SaveLocation<T>(T newLocation)
        {
            await App.Connection.InsertAsync(newLocation);
        }
                
        // public async Task<ObservableCollection<T>> LoadLocations() //Task<ObservableCollection<LocationUS>> LoadLocations()
        //{
        //    var result = new ObservableCollection<T>();

        //    for (int i = 0; i < 4; i++)
        //    {
        //        result.Add(
        //           new T
        //           {
        //               //LocationName = "PlaceName" + i,
        //               //LocationStreetAddress = "123 Address #" + i,
        //               //LocationCity = "City #" + i,
        //               //LocationState = "ST",
        //               //LocationZIP = "7511" + i
        //           }
        //           );
        //    }

        //    return result;
        //}

        public async Task<List<Location>> LoadLocations() //Task<ObservableCollection<LocationUS>> LoadLocations()
        {
            var result = new List<Location>();

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
        
         public async Task UpdateLocation<T>(T selectedLocation)
        {
            await App.Connection.UpdateAsync(selectedLocation);
        }

        public async Task DeleteLocation<T>(T selectedLocation)
        {
            await App.Connection.DeleteAsync(selectedLocation);
        }


    }
}

