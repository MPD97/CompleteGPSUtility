using Newtonsoft.Json;
using System.Collections.Generic;

namespace Database
{
    public class InputProbeDataModel
    {
        [JsonProperty("l")]
        public List<InputLocationModel> Locations { get; set; } = new List<InputLocationModel>();
       
        [JsonProperty("p")]
        public byte VoltagePercentage { get; set; }             //Percentage voltage max = 4.2V, min = 3.5V?
        
        [JsonProperty("v")]
        public short Voltage { get; set; }                      //Voltage e.g. 3950 means 3,95V

        [JsonProperty("i")]
        public int CurrentInterval { get; set; }                //Current Time Interval of device

        [JsonProperty("k")]
        public string IMEI { get; set; }                        //IMEI
    }
}
