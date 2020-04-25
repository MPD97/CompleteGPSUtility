using System.Collections.Generic;

namespace Database
{
    public class ProbeDataModel
    {
        public List<LocationModel> l { get; set; } = new List<LocationModel>();

        public short p { get; set; }                    //Percentage voltage max = 4.2, min = 3.5?

        public short v { get; set; }                    //Voltage e.g. 3950 means 3,95V

        public decimal? i { get; set; }                 //Current Time Interval of device

        public string k { get; set; }                   //IMEI
    }
}
