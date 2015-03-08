using GalaSoft.MvvmLight;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmingTrafficWP8.Model
{
    //[Table("Locations")]
    public abstract class Location : ObservableObject
    {
        private int _id;
        private bool _isDirty;
        private string _LocationName;
        private string _LocationCountry;
        // private string _LocationStreetNum;
        private string _LocationStreetAddress;


        public Location() { }


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

        [NotNull]
        public string LocationName
        {
            get { return _LocationName; }
            set
            {
                if (Set(() => LocationName, ref _LocationName, value))
                {
                    IsDirty = true;
                }
            }
        }

        public string LocationCountry
        {
            get { return _LocationCountry; }
            set
            {
                if (Set(() => LocationCountry, ref _LocationCountry, value))
                {
                    IsDirty = true;
                }
            }
        }

        //public string LocationStreetNum
        //{
        //    get { return _LocationStreetNum; }
        //    set
        //    {
        //        if (Set(() => LocationStreetNum, ref _LocationStreetNum, value))
        //        {
        //            IsDirty = true;
        //        }
        //    }
        //}

        [NotNull]
        public string LocationStreetAddress
        {
            get { return _LocationStreetAddress; }
            set
            {
                if (Set(() => LocationStreetAddress, ref _LocationStreetAddress, value))
                {
                    IsDirty = true;
                }
            }
        }

        //// Create a copy of an location to save.
        //// If your object is databound, this copy is not databound.        
        //public Location GetCopy()
        //{
        //    Location copy = (Location)this.MemberwiseClone();
        //    return copy;
        //}
    }
}
