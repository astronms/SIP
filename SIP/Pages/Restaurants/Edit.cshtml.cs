using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SIP.Data.Restaurants;
using Microsoft.AspNetCore.Http;
using System.Web;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Authorization;

namespace SIP.Pages.Restaurants
{
    [Authorize(Roles = "Menager")]
    public class editModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public editModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IActionResult OnGet(int? restaurantId, string restaurantLat, string restaurantLng)
        {
            if (restaurantId > 0)
            {
                Restaurant = _restaurantData.GetById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
                if (restaurantLat != null || restaurantLng != null) 
                {
                    Restaurant.Latitude = restaurantLat;
                    Restaurant.Longitude = restaurantLng;
                }

            }
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                //throw NotImplementedException();
                return Page();

            }

            if (Restaurant.Id > 0)
            {
                _restaurantData.Update(Restaurant);
            }
            else
            {
                _restaurantData.Add(Restaurant);
            }

            _restaurantData.Commit();
            TempData["Message"] = "Zapisano Restauracjê!";
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }

    }

}