using GalaSoft.MvvmLight.Messaging;

namespace AlarmingTrafficWP8.Messages
{
    public class LocationSelectedMessage : MessageBase
    {
        public Model.Location Location { get; set; }

        public LocationSelectedMessage(Model.Location location)
        {
            Location = location;
        }
    }
}
