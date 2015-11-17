using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MovieShopDAL.Repository
{
    internal class MovieRepository : IRepository<Movie>
    {

        public void Add(Movie entity)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                db.Movies.Add(entity);
                db.SaveChanges();
            }
        }

        public void Edit(Movie entity)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Movie Get(int id)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                //return db.Movies.Include(c => c.Category).FirstOrDefault(m => m.Id == id);

                return db.Movies.FirstOrDefault(m => m.Id == id);
            }
        }

        public IEnumerable<Movie> GetAll()
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                //return db.Movies.Include(c => c.Category).ToList();
                return db.Movies.ToList();
            }
        }

        public void Remove(int id)
        {
            using (MovieStoreDbContext db = new MovieStoreDbContext())
            {
                var movies = db.Movies.Find(id);
                db.Movies.Remove(movies);
                db.SaveChanges();
            }
        }
    }

    }