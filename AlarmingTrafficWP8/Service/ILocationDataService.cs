using AlarmingTrafficWP8.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AlarmingTrafficWP8.Service
{
    public interface ILocationDataService
    {
        Task SaveLocation<T>(T newLocation);
        Task<ObservableCollection<LocationUS>> LoadLocations();
        Task UpdateLocation<T>(T selectedLocation);
        Task DeleteLocation<T>(T selectedLocation);
    }
}
