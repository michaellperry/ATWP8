using GalaSoft.MvvmLight.Messaging;

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
