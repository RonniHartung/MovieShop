﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MovieShopDAL
{

    public class DBinit: DropCreateDatabaseAlways<MovieStoreDbContext>
    {
       public void ClearTables(MovieStoreDbContext context)
        {
            var listOfTables = new List<string> { "Categories", "Customers", "Movies", "OrderContents", "Orders" };

            foreach (var tableName in listOfTables)
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [" + tableName + "]");
            }

            context.SaveChanges();
        }

        protected override void Seed(MovieStoreDbContext context)
        {
            context.Categories.Add(new Category { Id = 1, CategoryName = "Action" });
            context.Categories.Add(new Category { Id = 2, CategoryName = "Comedy" });
            context.Categories.Add(new Category { Id = 3, CategoryName = "Thriller" });
            context.Categories.Add(new Category { Id = 4, CategoryName = "Sci-Fi" });
            context.Categories.Add(new Category { Id = 5, CategoryName = "Drama" });

            context.Movies.Add(new Movie { Id = 1, Title = "Die Hard 4.0", Price = 99.00m, CategoryId = 1, ImageUrl = "die4.jpg" });
            context.Movies.Add(new Movie { Id = 2, Title = "The Godfather", Price = 80.00m, CategoryId = 5, ImageUrl = "The Godfather.jpg", TrailerUrl = "http://www.youtube.com/watch?v=3EUJYh32KVw" });
            context.Movies.Add(new Movie { Id = 3, Title = "The Shining", Price = 50.00m, CategoryId = 3, ImageUrl = "The Shining.jpg", TrailerUrl = "https://www.youtube.com/watch?v=S014oGZiSdI" });
            context.Movies.Add(new Movie { Id = 4, Title = "Interstellar", Price = 90.00m, CategoryId = 1, ImageUrl = "interstella.jpg" });
            context.Movies.Add(new Movie { Id = 5, Title = "Pulp Fiction", Price = 67.00m, CategoryId = 2, ImageUrl = "pulpfiction.jpg" });


            context.Customers.Add(new Customer { Id = 1, Firstname = "Kritjan Thor", Lastname = "Hedinsson", Adresse = "Unknown", Email = "post@kritjanthor.dk", Phone = 27351394, Password = "test" });
            context.Customers.Add(new Customer { Id = 2, Firstname = "Ronni", Lastname = "Hartung", Adresse = "Skoleparken 65 7 tv", Email = "mail@hartnet.dk", Phone = 22334455, Password = "test1234" });

            var order1 = new Order { CustomerId = 1, OrderDate = DateTime.Now };

            context.Orders.Add(order1);

            base.Seed(context);
        }
    }

}