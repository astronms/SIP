using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace SIP.Data.Restaurants
{
    public class Rating
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int Score { get; set; }
        public string UserId { get; set; }
    }
}
