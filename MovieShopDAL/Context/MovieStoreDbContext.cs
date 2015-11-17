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
            /* 
            This setting will disable lazy loading of navigation
            property values and change tracking of the entity. Both 
            features are associated with virtual navigation properties.
            If proxy creation is enabled, it is not possible to serialize 
            an entity object with one or more virtual navigation properties 
            to JSON or XML, and Web API depends on this feature. 
            */
            Configuration.ProxyCreationEnabled = false;

            /*
            It is also possible to keep proxy creation enabled and just
            disable lazy loading as shown below. Then it is possible to
            serialize to JSON but not to XML.
            */
            //Configuration.LazyLoadingEnabled = false;       
        }

        public System.Data.Entity.DbSet<Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<Category> Categories { get; set; }

        public System.Data.Entity.DbSet<Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<Order> Orders { get; set; }
        public System.Data.Entity.DbSet<OrderContent> OrderContents {get; set;}

    }
}
