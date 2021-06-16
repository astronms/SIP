using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SIP.Data.Restaurants;


namespace SIP.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant { get; set; }
        [BindProperty]
        public Comment Comment { get; set; }
        [BindProperty]
        public Rating Rating { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public bool IsUserLogged { get; set; }
        public double RestaurantRate { get; set; }
        public int RestaurantNumberOfRates { get; set; }
        private readonly IRestaurantData _restaurantData;
        private readonly ICommentData _commentData;
        private readonly IRatingData _ratingData;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [TempData]
        public string Message { get; set; }

        public DetailModel(IRestaurantData restaurantData, ICommentData commentData, IRatingData ratingData, IHttpContextAccessor httpContextAccessor)
        {
            _restaurantData = restaurantData;
            _commentData = commentData;
            _ratingData = ratingData;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            IsUserLogged = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

            Comment = new Comment();
            Comment.UserName = _httpContextAccessor.HttpContext.User.Identity.Name;
            Comment.RestaurantId = Restaurant.Id;

            Comments = _commentData.GetRestaurantComments(Restaurant.Id);

            RestaurantRate = _ratingData.GetRestaurantRate(Restaurant.Id);
            RestaurantNumberOfRates = _ratingData.GetNumberOfRates(Restaurant.Id);

            Rating = new Rating();
            if (IsUserLogged)
            {
                Rating.UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            Rating.RestaurantId = Restaurant.Id;
            Rating.Score = 0;
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            Restaurant = _restaurantData.GetById(restaurantId);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Comment.Text != null)
            {
                _commentData.Add(Comment);
                _commentData.Commit();
                return RedirectToPage("./Detail", new { restaurantId = Comment.RestaurantId });
            }

            else if (Rating.Score != 0)
            {
                _ratingData.AddOrUpdate(Rating);
                _ratingData.Commit();
                return RedirectToPage("./Detail", new { restaurantId = Comment.RestaurantId });
            }
            else
                return RedirectToPage("./Detail", new { restaurantId = Comment.RestaurantId });
        }
        [BindProperty]
        public string Lat { get; set; }
        [BindProperty]
        public string Lng { get; set; }
    }
}