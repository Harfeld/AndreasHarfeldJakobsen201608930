using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace WEBApplikation.Models
{
    public class Sensor
    {
        [Required]
        [MinLength(16)]
        [MaxLength(16)]
        public string SensorId { get; set; }
        [Required] public string Species { get; set; }
        [Required] public double Latitude { get; set; }
        [Required] public double Lontitude { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
