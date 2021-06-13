using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SIP.Data.Restaurants
{
    public class Comment
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
    }
}
