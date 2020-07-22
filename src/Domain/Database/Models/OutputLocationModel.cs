using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class OutputLocationModel
    {
        [JsonProperty("Lat")]
        public decimal Latitude { get; set; }
       
        [JsonProperty("Lon")]
        public decimal Longitude { get; set; }

        [JsonProperty("Alt")]
        public int Altitude { get; set; }
        
        [JsonProperty("Y2k")]
        public int TimeFrom2000 { get; set; }

        public short BatteryPercentage { get; set; }
        public int BatteryVoltage { get; set; }
        public int CurrentInterval { get; set; }
    }
}
