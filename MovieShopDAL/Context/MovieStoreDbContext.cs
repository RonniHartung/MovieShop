using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieShopDAL
{
    public class MovieStoreDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public MovieStoreDbContext() : base("name=MovieStoreDbContext")
        {
        }

        public System.Data.Entity.DbSet<Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<Category> Categories { get; set; }

        public System.Data.Entity.DbSet<Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<Order> Orders { get; set; }
        public System.Data.Entity.DbSet<OrderContent> OrderContents {get; set;}

       // public System.Data.Entity.DbSet<MovieShopUI.Models.ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
