using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDataContext _foodDataContext;

        public SqlRestaurantData(OdeToFoodDataContext foodDataContext)
        {
            _foodDataContext = foodDataContext;
        }
        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            if (restaurant !=null)
            {
                _foodDataContext.Add(restaurant);
            };
           
            return restaurant;
        }

        public int Commit()
        {
            return _foodDataContext.SaveChanges();
        }

        public Restaurant DeleteRestaurant(int id)
        {
            var restaurant = GetRestaurantById(id);
            if (restaurant != null)
            {
                _foodDataContext.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _foodDataContext.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from restaurant in _foodDataContext.Restaurants
                        where restaurant.Name.Contains(name) || string.IsNullOrEmpty(name)
                        orderby restaurant.Id
                        select restaurant;
            return query;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var entity = _foodDataContext.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
            return restaurant;
        }
    }
}
