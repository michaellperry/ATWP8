using GalaSoft.MvvmLight;
using SQLite;

namespace AlarmingTrafficWP8.Model
{
    [Table("LocationsUS")]
    public class LocationUS : Location
    {
        //private int _id;
        //private bool _isDirty;
        //private string _LocationName;
        //private string _LocationStreetNum;
        //private string _LocationStreetAddress;
        private string _LocationCity;
        private string _LocationState;
        private string _LocationZIP;
       


        ///// <summary>
        ///// You can create an integer primary key and let the SQLite control it.
        ///// </summary>
        //[PrimaryKey, AutoIncrement]
        //public int Id
        //{
        //    get
        //    {
        //        return _id;
        //    }
        //    set
        //    {
        //        Set(() => Id, ref _id, value);
        //    }
        //}

        //[Ignore]
        //public bool IsDirty
        //{
        //    get { return _isDirty; }
        //    set { Set(() => IsDirty, ref _isDirty, value); }
        //}


        //public string LocationName
        //{
        //    get { return _LocationName; }
        //    set
        //    {
        //        if (Set(() => LocationName, ref _LocationName, value))
        //        {
        //            IsDirty = true;
        //        }
        //    }
        //}


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
        
        //public string LocationStreetAddress
        //{
        //    get { return _LocationStreetAddress; }
        //    set
        //    {
        //        if (Set(() => LocationStreetAddress, ref _LocationStreetAddress, value))
        //        {
        //            IsDirty = true;
        //        }
        //    }
        //}
        
        public string LocationCity
        {
            get { return _LocationCity; }
            set
            {
                if (Set(() => LocationCity, ref _LocationCity, value))
                {
                    IsDirty = true;
                }
            }
        }
        
        [MaxLength(2)]
        public string LocationState
        {
            get { return _LocationState; }
            set
            {                
                if (Set(() => LocationState, ref _LocationState, value))
                {
                    IsDirty = true;
                }
            }
        }
        
        [MaxLength(5)]
        public string LocationZIP
        {
            get { return _LocationZIP; }
            set
            {
                if (Set(() => LocationZIP, ref _LocationZIP, value))
                {
                    IsDirty = true;
                }
            }
        }       


        // Create a copy of an location to save.
        // If your object is databound, this copy is not databound.        
        public LocationUS GetCopy()
        {
            LocationUS copy = (LocationUS)this.MemberwiseClone();
            return copy;
        }
    }
}
