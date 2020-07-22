using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Entities
{
    public class Device
    {
        public short DeviceId { get; set; }

        [MaxLength(15)]
        public string IMEI { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        public virtual IEnumerable<Location> Locations { get; set; }
        public virtual IEnumerable<Access> Accesses { get; set; }
    }
}
