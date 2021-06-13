using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIP.Data.Restaurants
{
    public class Rating
    {
        public int Id { get; set; }
        public Restaurant Restaurant { get; set; }
        public int Score { get; set; }
    }
}
