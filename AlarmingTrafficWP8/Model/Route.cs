using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using SQLite;

namespace AlarmingTrafficWP8.Model
{
    [Table("Routes")]
    public class Route : ObservableObject
    {
        private int _id;
        private bool _isDirty;
        private string _RouteName;
        private string _RouteStart;
        private int _LocationId1;
        private int _LocationId2;
        private int _LocationId3;


        /// <summary>
        /// You can create an integer primary key and let the SQLite control it.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                Set(() => Id, ref _id, value);
            }
        }


        [Ignore]
        public bool IsDirty
        {
            get { return _isDirty; }
            set { Set(() => IsDirty, ref _isDirty, value); }
        }


        public string RouteName
        {
            get { return _RouteName; }
            set
            {
                Set(() => RouteName, ref _RouteName, value);
            }
        }


        public string RouteStart
        {
            get { return _RouteStart; }
            set
            {
                Set(() => RouteStart, ref _RouteStart, value);
            }
        }

        // use the locationIDs as the start/destinations - the columns will hold the primary keys of the locations
        // and the code will linq with them to populate drop box - WAYPOINT0-2

        /// <summary>
        /// Will need to collect all of the LocationIds for the route
        /// </summary>
        [Indexed]
        public int LocationId1
        {
            get { return _LocationId1; }
            set
            {
                Set(() => LocationId1, ref _LocationId1, value);
            }
        }




        [Indexed]
        public int LocationId2
        {
            get { return _LocationId2; }
            set
            {
                Set(() => LocationId2, ref _LocationId2, value);
            }
        }

        [Indexed]
        public int LocationId3
        {
            get { return _LocationId3; }
            set
            {
                Set(() => LocationId3, ref _LocationId3, value);
            }
        }



        // Create a copy of an route to save.
        // If your object is databound, this copy is not databound.

        public Route GetCopy()
        {
            Route copy = (Route)this.MemberwiseClone();
            return copy;
        }


        // Set(() => , ref , value);

    }
}
