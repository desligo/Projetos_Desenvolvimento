using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;
        public IEnumerable<Restaurant> Restaurants { get; set; }
        
        [TempData]
        public string TempDataMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this._config = config;
            this._restaurantData = restaurantData;
        }
        public void OnGet(string searchTerm)
        {
            Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm);
           //     TempData["TempDataMessage"] = "Nenhum restaurante encontrado";
        }
    }
}
