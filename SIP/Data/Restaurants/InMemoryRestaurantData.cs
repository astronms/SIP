using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIP.Data.Restaurants
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public static List<Restaurant> _restaurants;
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Surf Burger Przymorze", Longitude = "18.577656847200338", Latitude = "54.40227314033461"},
                new Restaurant {Id = 2, Name = "Burger King - Galeria Bałtycka", Longitude = "18.60111520254226", Latitude = "54.38314106946464"},
                new Restaurant {Id = 3, Name = "Śródmieście", Longitude = "18.53776116646959", Latitude = "54.52023312072917"},
                new Restaurant {Id = 4, Name = "Lee's Chinese", Longitude = "18.634016378122386", Latitude = "54.35063512763745"},
                new Restaurant {Id = 5, Name = "Burger vs Kebab", Longitude = "18.946470450646416", Latitude = "50.29056305352822"},
                new Restaurant {Id = 6, Name = "Maszoperia", Longitude = "18.804862226805344", Latitude = "54.60269856595142"},
                new Restaurant {Id = 7, Name = "Nasty Burger", Longitude = "18.789172951387496", Latitude = "54.093084407168426"}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in _restaurants
                where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                orderby r.Name
                select r;
        }

        public Restaurant GetById(int id)
        {
            return _restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = _restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Longitude = updatedRestaurant.Longitude;
                restaurant.Latitude = updatedRestaurant.Latitude;
            }

            return restaurant;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _restaurants.Add(newRestaurant);
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }
    }
}
