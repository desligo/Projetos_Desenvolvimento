using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OdeToFood.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly OdeToFoodDataContext _odeToFoodDataContext;

        public RestaurantsController(OdeToFoodDataContext odeToFoodDataContext)
        {
            _odeToFoodDataContext = odeToFoodDataContext;
        }
       
        [HttpGet]
        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _odeToFoodDataContext.Restaurants;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurant([FromBody] Restaurant GetRestaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var restaurant = await _odeToFoodDataContext.Restaurants.FindAsync(GetRestaurant.Id);
            if(restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }
    
        [HttpPut("id")]
        public async Task<IActionResult> PutRestaurant([FromBody] Restaurant restaurant, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != restaurant.Id)
            {
                return BadRequest();
            }
            _odeToFoodDataContext.Entry(restaurant).State = EntityState.Modified;

            try
            {
                await _odeToFoodDataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool RestaurantExists(int id)
        {
           var restaurant =  _odeToFoodDataContext.Restaurants.FirstOrDefaultAsync(p=>p.Id == id);
            if (restaurant != null)
                return true;
            return false;
        }
    }
}
