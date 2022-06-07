using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {

        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ Id = 1, Name = "Pizza Hut", Location = "Brasil", Cuisine = CuisineType.Italian},
                new Restaurant{ Id = 2, Name = "Cinnamon", Location = "Londres", Cuisine = CuisineType.Mexican},
                new Restaurant{ Id = 3, Name = "CPQ", Location = "EUA", Cuisine = CuisineType.Indian}
            };
        }

        public Restaurant AddRestaurant(Restaurant Newrestaurant)
        {
            restaurants.Add(Newrestaurant);
            Newrestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return Newrestaurant;

        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant DeleteRestaurant(int id)
        {
            var restaurant = GetRestaurantById(id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.ToUpper().Contains(name.ToUpper())
                   orderby r.Id descending

                   select r;

        }

        public Restaurant Update(Restaurant Updaterestaurant)
        {
            var restaurant = GetRestaurantById(Updaterestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = Updaterestaurant.Name;
                restaurant.Location = Updaterestaurant.Location;
                restaurant.Cuisine = Updaterestaurant.Cuisine;

            }
            return restaurant;
        }
    }
}
