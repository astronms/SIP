using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SIP.Data.Restaurants;


namespace SIP.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant { get; set; }
        private readonly IRestaurantData _restaurantData;

        [TempData]
        public string Message { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            Restaurant = _restaurantData.GetById(restaurantId);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return Redirect("http://maps.google.com/maps?saddr=" + Restaurant.Latitude + "," + Restaurant.Longitude +
                            "&daddr=" + Lat + "," + Lng);
        }
        [BindProperty]
        public float Lat { get; set; }
        [BindProperty]
        public float Lng { get; set; }
    }
}