using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MovieShopDAL
{
    //public class DBinit : DropCreateDatabaseIfModelChanges<MovieStoreDbContext>
    //{
    //    Artist myArtist = new Artist { name = "Tool", id=1 };
    //    Genre myGenre = new Genre { name = "Metal", id = 1 };

    //    protected override void Seed(Context context)
    //    {
    //        Album myAlbum = new Album { id = 1, title = "Enigma", price = 10.99m, releaseDate = DateTime.Now, Artist = myArtist, Genre = myGenre };

    //        context.Genres.Add(myGenre);
    //        context.Artists.Add(myArtist);
    //        context.Albums.Add(myAlbum);

    //        base.Seed(context);
    //    }
    //}

    public class DBinit : DropCreateDatabaseAlways <MovieStoreDbContext>
    {
      
        protected override void Seed(MovieStoreDbContext context)
        {
            context.Categories.Add(new Category { CategoryName = "Action" });
            context.Categories.Add(new Category { CategoryName = "Comedy" });

            var movie1 = new Movie { Title = "Die Hard 4.0", Price = 99.00m, CategoryId = 1 };
                context.Movies.Add(movie1);

            context.Customers.Add(new Customer { Id = 1, Firstname = "Kritjan Thor", Lastname = "Hedinsson", Adresse = "Unknown", Email = "post@kritjanthor.dk", Password = "test" });

            var order1 = new Order { Id = 1, CustomerId = 1, OrderDate = DateTime.Now };
            context.Orders.Add(order1);

            context.OrderContents.Add(new OrderContent { Id =1, Movie=movie1, Order=order1 });
            
            base.Seed(context);
        }
    }







}