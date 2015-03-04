using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AlarmingTrafficWP8.Model;
using Sqlite;

namespace AlarmingTrafficWP8.Service
{
    public class LocationDataService : ILocationDataService
    {
        private ObservableCollection<LocationUS> _locations = null; // new ObservableCollection<Location>();

        public async Task SaveLocation<T>(T newLocationUS)
        {
            await App.Connection.InsertAsync(newLocationUS);
        }

        // Must be upgraded to return any/all Location Data
        public async Task<ObservableCollection<LocationUS>> LoadLocations()
        {
            _locations = new ObservableCollection<LocationUS>();

            //ObservableCollection<T> _locations = new ObservableCollection<T>();            
            //List<object> tableList = null;
            //List<T> list = null; 

            try
            {

                var existingTables =
                    App.Connection.QueryAsync<sqlite_master>("SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;")
                      .GetAwaiter()
                      .GetResult();

                //foreach (var table in existingTables)
                //{
                //    tableList.Add(table);                 

                //}

                //foreach (var item in tableList)
                //{
                //    if (item.ToString().Contains("Location"))
                //    {
                //        list = await App.Connection.Table<item>().OrderBy(x => x.LocationName).ToListAsync();
                //    }
                //}


                //if ( table.name.Contains()  )
                //    {
                //        list = await App.Connection.Table<GetType(table.name.ToString())>().OrderBy(x => x.LocationName).ToListAsync();

                //        foreach (var item in list)
                //        {
                //            this._locations.Add(item);
                //        }

                //    }


                // List<Location>
                var list = await App.Connection.Table<LocationUS>().OrderBy(x => x.LocationName).ToListAsync();

                foreach (var item in list)
                {
                    this._locations.Add(item);
                }
            }
            catch (Exception exc)
            {

                _locations = null;
            }


            return _locations;
        }

        public async Task UpdateLocation<T>(T selectedLocation)
        {

            //      var oldLocation = _locations.FirstOrDefault(
            //l => l.Id == selectedLocation.Id);

            //      if (oldLocation == null)
            //      {
            //          throw new System.ArgumentException(
            //                  "Location not found.");
            //      }
            //      _locations.Remove(oldLocation);
            //      _locations.Add(selectedLocation);

            await App.Connection.UpdateAsync(selectedLocation);
        }

        public async Task DeleteLocation<T>(T selectedLocation)
        {
            // _locations.Remove(selectedLocation);
            await App.Connection.DeleteAsync(selectedLocation);
        }


    }
}


// http://stackoverflow.com/questions/18553662/how-to-convert-querytable-to-observablecollection
// http://social.msdn.microsoft.com/Forums/windowsapps/en-US/53f00dd4-e323-4555-89b7-0ca7619f762e/sqlite-database-query
// http://blog.alectucker.com/post/2014/08/01/azure-mobile-services-with-xamarin-forms.aspx
// 