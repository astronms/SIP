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
        [RegularExpression(@"^[-+]?([1-8]?\d(\.\d+)?|90(\.0+)?)"), Required, StringLength(30)]
        public string Latitude { get; set; }
        [RegularExpression(@"^[-+]?([1-8]?\d(\.\d+)?|90(\.0+)?)"), Required, StringLength(30)]
        public string Longitude { get; set; }
        public string Address { get; set; }
        public RestaurantType Type { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
    }
}
