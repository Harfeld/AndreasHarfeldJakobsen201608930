using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApplikation.Models
{
    public class Tree
    {
        public int TreeId { get; set; }
        [Required] public int Amount { get; set; }
        [Required] public string Species { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
