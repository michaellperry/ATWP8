using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using AlarmingTrafficWP8.Behaviors;
using AlarmingTrafficWP8.Messages;
using AlarmingTrafficWP8.Model;

namespace AlarmingTrafficWP8.Messages
{
    public class RouteSelectedMessage : MessageBase
    {
        public Model.Route Route { get; set; }

        public RouteSelectedMessage(Model.Route route)
        {
            Route = route;
        }
    }
}
