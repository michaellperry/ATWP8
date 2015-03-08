using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmingTrafficWP8.Model
{
    // Canada
    [Table("LocationsCA")]
    public class LocationCA : Location
    {  // Municipality Name, Province or Territory and Postal Code


        private string _Municipality;
        private string _Province;
        private string _PostalCode;


        /// <summary>
        /// Canadian City
        /// </summary>
        public string Municipality
        {
            get { return _Municipality; }
            set
            {
                if (Set(() => Municipality, ref _Municipality, value))
                {
                    IsDirty = true;
                }
            }
        }


        /// <summary>
        /// Canadian Province or Territory
        /// </summary>
        [MaxLength(2)]
        public string Province
        {
            get { return _Province; }
            set
            {
                if (Set(() => Province, ref _Province, value))
                {
                    IsDirty = true;
                }
            }
        }


        /// <summary>
        /// Canadian Postal Code
        /// </summary>
        /// 
        [MaxLength(7)]
        public string PostalCode
        {
            get { return _PostalCode; }
            set
            {
                if (Set(() => PostalCode, ref _PostalCode, value))
                {
                    IsDirty = true;
                }
            }
        }

        /// <summary>
        /// Create a return string with the whole address
        /// </summary>
        [Ignore]
        public string FullAddress
        {
            get
            {
                return String.Format("{0}, {1}, {2}, {3}",
                    LocationStreetAddress, Municipality, Province, PostalCode);
            }

        }


        // Create a copy of an location to save.
        // If your object is databound, this copy is not databound.        
        public LocationCA GetCopy()
        {
            LocationCA copy = (LocationCA)this.MemberwiseClone();
            return copy;
        }
    }
}
