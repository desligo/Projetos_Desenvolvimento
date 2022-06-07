using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            if (restaurantId.HasValue)
            {
                Restaurant = _restaurantData.GetRestaurantById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
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
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();

                return Page();
            }
            if(Restaurant.Id > 0)
            {
                _restaurantData.Update(Restaurant);
            }
            else
            {
                _restaurantData.AddRestaurant(Restaurant);
                TempData["TempDataMessage"] = "Restaurante criado com sucesso";
            }
            _restaurantData.Commit();
            
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });



        }
    }
}
