using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIP.Data.Restaurants
{
    public interface ICommentData
    {
        Comment Add(Comment newComment);
        Comment GetById(int id);
        Comment Delete(int id);
        Comment GetEmptyComment();

        IEnumerable<Comment> GetRestaurantComments(int restaurantID);
        int Commit();
    }
}
