using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIP.Data.Restaurants
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string Address { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
