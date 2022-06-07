using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public class OdeToFoodDataContext : DbContext
    {
        public OdeToFoodDataContext(DbContextOptions<OdeToFoodDataContext> options): base (options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
