using OdeToFood.Core;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);

        Restaurant Update(Restaurant restaurant);

        Restaurant AddRestaurant(Restaurant restaurant);

        Restaurant DeleteRestaurant(int id);
        int Commit();
        int GetRestaurantCount();
    }
}
