using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SIP.Data.Restaurants;

namespace SIP.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRestaurantData _restaurantData; //
        public static bool IsPost { get; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IEnumerable<Restaurant> Restaurants { get; set; } //

        [BindProperty]
        public string City { get; set; }
        public void OnPost()
        {
            City = Request.Form["city"];
        }
    }
}
