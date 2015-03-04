using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Messaging;
using AlarmingTrafficWP8.Behaviors;
using AlarmingTrafficWP8.Messages;
using AlarmingTrafficWP8.Model;

namespace AlarmingTrafficWP8.Messages
{
    public class LocationSelectedMessage : MessageBase
    {
        
        //public T Location { get; set; }

        //public LocationSelectedMessage(T location)
        //{
        //    Location = location;
        //}


        
        public Model.LocationUS Location { get; set; }

        public LocationSelectedMessage(Model.LocationUS location)
        {
            Location = location;
        }
         
    }
}
