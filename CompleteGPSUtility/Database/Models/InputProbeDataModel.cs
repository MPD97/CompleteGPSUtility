using System.Collections.Generic;

namespace Database
{
    public class InputProbeDataModel
    {
        public List<InputLocationModel> l { get; set; } = new List<InputLocationModel>();

        public byte p { get; set; }                    //Percentage voltage max = 4.2V, min = 3.5V?

        public short v { get; set; }                    //Voltage e.g. 3950 means 3,95V

        public int i { get; set; }                 //Current Time Interval of device

        public string k { get; set; }                   //IMEI
    }
}
