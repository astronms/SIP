using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using SIP.Data.Restaurants;

namespace SIP.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;

        public string Message { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }
        public string SearchAddress { get; set; }
        public int MinScore{ get; set; }
        public int MaxScore { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            _config = config;
            _restaurantData = restaurantData;
            _restaurantData = restaurantData;
        }
        public void OnGet(string searchName, string searchAddress, int minScore, int maxScore)
        {
            SearchName = searchName;
            SearchAddress = searchAddress;
            MinScore = minScore;
            MaxScore = maxScore;

            Restaurants = _restaurantData.SearchRestaurants(SearchName, SearchAddress, MinScore, MaxScore);
        }
    }
}