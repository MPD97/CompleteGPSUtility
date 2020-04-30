using System.Collections;

namespace Database.Entities
{
    public class Location
    {
        public int LocationId { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public short Altitude { get; set; }

        public short BatteryVoltage { get; set; }
        public byte BatteryPercentage { get; set; }

        public int TimeUnix { get; set; }


        public short DeviceId { get; set; }
        public Device Device { get; set; }
    }
}
