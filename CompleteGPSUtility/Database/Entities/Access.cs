using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Entities
{
    public class Access
    {
        public short AccessId { get; set; }


        public short DeviceId { get; set; }
        public Device Device { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
