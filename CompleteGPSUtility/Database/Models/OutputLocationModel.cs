using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class OutputLocationModel
    {
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public int Alt { get; set; }
        public  int Y2k { get; set; }
        public short BatteryPercentage { get; set; }
        public int BatteryVoltage { get; set; }
        public int CurrentInterval { get; set; }
    }
}
