namespace Database
{
    public class LocationModel
    {
        public decimal a { get; set; }                  //Latatitude decimal
        public decimal o { get; set; }                  //Longitude decimal
        public short? l { get; set; }                 //Altitude in meters
        public int y { get; set; }                      //Y2K = Seconds from 2000-01-01 in UTC
    }
}
