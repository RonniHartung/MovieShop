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

    public class DBinit : DropCreateDatabaseIfModelChanges<MovieStoreDbContext>
    {
        Category newCategory = new Category { CategoryId = 1, CategoryName = "Action" };
        Category newCategory1 = new Category { CategoryId = 2, CategoryName = "Comedy" };

        Movie newMovie = new Movie { MovieId = 1, Title = "Die Hard 4.0", CategoryId = 1, Price = 99.00m };




        Customer newCustomer = new Customer { CustomerId = 1, Firstname = "Kritjan Thor", Lastname = "Hedinsson", Adresse = "Unknown", Email = "post@kritjanthor.dk" };
        
        protected override void Seed(MovieStoreDbContext context)
        {
            context.Categories.Add(newCategory);
            context.Categories.Add(newCategory1);
            context.Movies.Add(newMovie);
            context.Customers.Add(newCustomer);
            base.Seed(context);
        }
    }
        
        
        
        
        
        
        
        }