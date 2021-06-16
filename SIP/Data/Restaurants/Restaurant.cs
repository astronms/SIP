using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SIP.Data.Restaurants
{
    public class Restaurant
    {
        public Restaurant()
        {
            Hours = new List<RestaurantHours>();
            for(int i = 0; i < 7; i++)
            {
                Hours.Add(new RestaurantHours());
            }
        }
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [RegularExpression(@"^[-+]?([1-8]?\d(\.\d+)?|90(\.0+)?)"), Required, StringLength(30)]
        public string Latitude { get; set; }
        [RegularExpression(@"^[-+]?([1-8]?\d(\.\d+)?|90(\.0+)?)"), Required, StringLength(30)]
        public string Longitude { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }   
        public RestaurantType Type { get; set; }
        public List<RestaurantHours> Hours {get; set;}
        public string Description { get; set; }
        public double Rating { get; set; }
        public string AdressURL { get; set; }

    }
}
