using Newtonsoft.Json;

namespace Database
{
    public class InputLocationModel
    {
        [JsonProperty("a")]
        public decimal Latitude { get; set; }                   //Latatitude decimal

        [JsonProperty("o")]
        public decimal Longitude { get; set; }                  //Longitude decimal

        [JsonProperty("l")]
        public short? Altitude { get; set; }                    //Altitude in meters

        [JsonProperty("y")]
        public int TimeFrom2000 { get; set; }                   //Y2K = Seconds from 2000-01-01 in UTC
    }
}
