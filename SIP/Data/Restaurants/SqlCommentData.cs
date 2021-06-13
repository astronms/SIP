using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SIP.Data.Restaurants
{
    public class SqlCommentData : ICommentData
    {
        private readonly ApplicationDbContext db;
        public SqlCommentData(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Comment Add(Comment newComment)
        {
            db.Add(newComment);
            return newComment;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Comment GetById(int id)
        {
            return db.Comments.Find(id);
        }

        public Comment Delete(int id)
        {
            var comment = GetById(id);
            if (comment != null)
            {
                db.Comments.Remove(comment);
            }

            return comment;
        }

        public Comment GetEmptyComment()
        {
            return new Comment();
        }

        public IEnumerable<Comment> GetRestaurantComments(int restaurantID)
        {
            return db.Comments.Where(c => c.RestaurantId == restaurantID);
        }
    }
}
