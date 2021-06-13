using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIP.Data.Restaurants
{
    public class SqlRatingData : IRatingData
    {
        private readonly ApplicationDbContext db;
        public SqlRatingData(ApplicationDbContext db)
        {
            this.db = db;
        }
        public double GetRestaurantRate(int restaurantId)
        {
            var tmp = db.Ratings.Where(st => st.RestaurantId == restaurantId);
            if (tmp.Count() == 0)
                return 0;
            else
                return tmp.Average(st => st.Score);
        }

        public int GetNumberOfRates(int restaurantId)
        {
            var tmp = db.Ratings.Where(st => st.RestaurantId == restaurantId).ToList();
            if (tmp is null)
                return 0;
            else
                return tmp.Count();
        }

        public Rating AddOrUpdate(Rating rate)
        {
            var tmp = db.Ratings.Where(st => st.UserId == rate.UserId && st.RestaurantId == rate.RestaurantId).FirstOrDefault();
            if (tmp != null)
            {
                tmp.Score = rate.Score;
            }
            else
                db.Add(rate);

            return rate;           
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}
