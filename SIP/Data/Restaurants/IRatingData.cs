using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIP.Data.Restaurants
{
    public interface IRatingData
    {
        double GetRestaurantRate(int restaurantId);
        int GetNumberOfRates(int restaurantId);
        Rating AddOrUpdate(Rating rate);
        int Commit();
    }
}
