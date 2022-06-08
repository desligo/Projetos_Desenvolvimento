using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        public Restaurant  Restaurant { get; set; }
        public DeleteModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }

        public IActionResult OnPost(int restaurantId)
        {
            var restaurante = _restaurantData.DeleteRestaurant(restaurantId);
            _restaurantData.Commit();

            if (restaurante == null)
            {
                RedirectToPage("./NotFound");
            }

            TempData["TempDataMessage"] = $"{restaurante.Name} excluido com sucesso. ";
            return RedirectToPage("./List");
        }
    }
}
