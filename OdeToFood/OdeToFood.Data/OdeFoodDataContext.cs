using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public class OdeFoodDataContext : DbContext
    {
        public OdeFoodDataContext()
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
