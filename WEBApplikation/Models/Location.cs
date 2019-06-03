using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApplikation.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Road { get; set; }
        [Required] public string RoadNumber { get; set; }
        [Required] public int PostalCode { get; set; }
        [Required] public string City { get; set; }
        public List<Tree> Trees { get; set; }
        public List<Sensor> Sensors { get; set; }
    }
}
