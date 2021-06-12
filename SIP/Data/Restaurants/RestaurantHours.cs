using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIP.Data.Restaurants
{
    public class RestaurantHours
    {
        [Key]
        public int DayId { get; set; }
        public int OpenHour { get; set; }
        public int CloseHour { get; set; }

    }
}
