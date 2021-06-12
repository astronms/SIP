using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SIP.Data.Restaurants
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly ApplicationDbContext db;
        public SqlRestaurantData(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> SearchRestaurants(string name, string address, float minScore, float maxScore)
        {
            var restaurantsByName = from r in db.Restaurants
                where string.IsNullOrEmpty(name) || r.Name.Contains(name)
                orderby r.Name
                select r;
            var restaurantsByAddress = from r in restaurantsByName
                where string.IsNullOrEmpty(address) || r.City.Contains(address)
                select r;
            var restaurantsByRating = from r in restaurantsByAddress
                where minScore == 0 && maxScore == 0 || r.Rating >= minScore && r.Rating <= maxScore
                select r;

            return restaurantsByRating;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
